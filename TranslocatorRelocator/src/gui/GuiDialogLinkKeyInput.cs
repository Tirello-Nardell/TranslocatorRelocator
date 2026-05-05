using Vintagestory.API.Client;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;

namespace TranslocatorRelocator.src.gui
{
    public class GuiDialogLinkKeyInput : GuiDialogGeneric
    {
        private BlockPos blockEntityPos;

        const int MAX_KEY_LENGHT = 16;

        public GuiDialogLinkKeyInput(string DialogTitle, BlockPos pos, string linkKey, ICoreClientAPI capi) : base(DialogTitle, capi)
        {
            blockEntityPos = pos;
            ElementBounds textInputBounds = ElementBounds.Fixed(0.0, 0.0, (MAX_KEY_LENGHT*10)+26, 28);
            ElementBounds clipBounds1 = textInputBounds.ForkBoundingParent().WithFixedPosition(0.0, 30.0);
            ElementBounds cancelButtonBounds = ElementBounds.FixedSize(0.0, 0.0).FixedUnder(clipBounds1, 10.0).WithAlignment(EnumDialogArea.LeftFixed).WithFixedPadding(8.0, 2.0).WithFixedAlignmentOffset(-1.0, 0.0);
            ElementBounds saveButtonBounds = ElementBounds.FixedSize(0.0, 0.0).FixedUnder(clipBounds1, 10.0).WithAlignment(EnumDialogArea.RightFixed).WithFixedPadding(10.0, 2.0).WithFixedAlignmentOffset(6, 0);
            ElementBounds shadeElementBounds = ElementBounds.FixedSize((MAX_KEY_LENGHT * 10)+22, 90).WithFixedPadding(GuiStyle.ElementToDialogPadding);
            ElementBounds mainBounds = ElementStdBounds.AutosizedMainDialog.WithAlignment(EnumDialogArea.RightMiddle).WithFixedAlignmentOffset(0.0 - GuiStyle.DialogToScreenPadding, 0.0);
            CairoFont cairoFont = CairoFont.TextInput().WithFontSize(20).WithFont("Consolas");
            cairoFont.LineHeightMultiplier = 0.9;
            base.SingleComposer = capi.Gui.CreateCompo("blockentitytexteditordialog", mainBounds)
                .AddShadedDialogBG(shadeElementBounds)
                .AddDialogTitleBar(DialogTitle, OnTitleBarClose)
                .BeginChildElements(shadeElementBounds)
                .BeginClip(clipBounds1)
                .AddTextInput(textInputBounds, OnTextInputChanged, cairoFont, "linkKey")
                .EndClip()
                .AddSmallButton(Lang.Get("Cancel"), OnButtonCancel, cancelButtonBounds)
                .AddSmallButton(Lang.Get("Save"), OnButtonSave, saveButtonBounds)
                .EndChildElements()
                .Compose();
            base.SingleComposer.GetTextInput("linkKey").SetMaxHeight(100);
            base.SingleComposer.GetTextInput("linkKey").SetMaxLines(1);

            if (linkKey.Length > 0)
            {
                base.SingleComposer.GetTextInput("linkKey").SetValue(linkKey);
            }
        }

        private void OnTitleBarClose()
        {
            OnButtonCancel();
        }

        private void OnTextInputChanged(string value)
        {
            if (value.Length > MAX_KEY_LENGHT)
            {
                base.SingleComposer.GetTextInput("linkKey").SetValue(value.Remove(MAX_KEY_LENGHT));
            }
        }

        private bool OnButtonSave()
        {
            string linkKey = base.SingleComposer.GetTextInput("linkKey").GetText();
            OnSave(linkKey);
            TryClose();
            return true;
        }

        private bool OnButtonCancel()
        {
            TryClose();
            return true;
        }

        public override void OnKeyDown(KeyEvent args)
        {
            if (args.KeyCode == ((int)GlKeys.Enter) && base.SingleComposer.GetTextInput("linkKey").HasFocus)
            {
                OnButtonSave();
                return;
            }
            base.OnKeyDown(args);
        }

        private void OnSave(string linkKey)
        {
            byte[] data = SerializerUtil.Serialize(new EditLinkKeyPacket
            {
                LinkKey = linkKey,
            });
            capi.Network.SendBlockEntityPacket(blockEntityPos, 1002, data);
        }
    }
}
