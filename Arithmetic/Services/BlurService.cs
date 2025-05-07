using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Services
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class BlurService
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public int AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public int Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        public static void EnableBlur(Form form)
        {
            var accent = new AccentPolicy
            {
                AccentState = 3 // ACCENT_ENABLE_BLURBEHIND
            };

            int size = Marshal.SizeOf(accent);
            IntPtr accentPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData
            {
                Attribute = 19, // WCA_ACCENT_POLICY
                SizeOfData = size,
                Data = accentPtr
            };

            SetWindowCompositionAttribute(form.Handle, ref data);
            Marshal.FreeHGlobal(accentPtr);
        }
    }

}
