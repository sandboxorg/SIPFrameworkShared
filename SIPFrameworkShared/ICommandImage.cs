using System.Drawing;
using System.Reflection;

namespace RedGate.SIPFrameworkShared
{
    public interface ICommandImage
    {
        /// <returns>An integer index into a satellite dll, a bitmap, or an icon</returns>
        object GetImage();
    }

    public class CommandImageNone : ICommandImage
    {
        public object GetImage()
        {
            return null;
        }
    }

    public sealed class CommandImageForEmbeddedResources : ICommandImage
    {
        private readonly Bitmap m_Bitmap;
        private readonly Image m_Image;

        public CommandImageForEmbeddedResources(Assembly assembly, string resourceName)
        {
            m_Image = Image.FromStream(assembly.GetManifestResourceStream(resourceName));
            m_Bitmap = new Bitmap(m_Image);
        }

        public object GetImage()
        {
            return m_Image;
        }
    }

    public sealed class CommandImageIdForSatelliteResource : ICommandImage
    {
        private readonly int m_Id;

        public CommandImageIdForSatelliteResource(int id)
        {
            m_Id = id;
        }

        public object GetImage()
        {
            return m_Id;
        }
    }

    public sealed class CommandImageBitmap : ICommandImage
    {
        private readonly Bitmap m_Bitmap;

        public CommandImageBitmap(Bitmap bitmap)
        {
            m_Bitmap = bitmap;
        }

        public object GetImage()
        {
            return m_Bitmap;
        }
    }

    public sealed class CommandImageIcon : ICommandImage
    {
        private readonly Icon m_Icon;

        public CommandImageIcon(Icon icon)
        {
            m_Icon = icon;
        }

        public object GetImage()
        {
            return m_Icon;
        }
    }
}