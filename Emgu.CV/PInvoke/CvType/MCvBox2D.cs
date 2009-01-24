using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Emgu.CV.Structure
{
   /// <summary>
   /// Managed structure equivalent to CvBox2D
   /// </summary>
   [StructLayout(LayoutKind.Sequential)]
   public struct MCvBox2D : IConvexPolygonF
   {
      /// <summary>
      /// The center of the box
      /// </summary>
      public System.Drawing.PointF center;
      /// <summary>
      /// The size of the box
      /// </summary>
      public System.Drawing.SizeF size;
      /// <summary>
      /// The angle of the box
      /// </summary>
      public float angle;

      /// <summary>
      /// Create a MCvBox2D structure with the specific parameters
      /// </summary>
      /// <param name="center">The center of the box</param>
      /// <param name="size">The size of the box</param>
      /// <param name="angle">The angle of the box</param>
      public MCvBox2D(System.Drawing.PointF center, System.Drawing.SizeF size, float angle)
      {
         this.center = center;
         this.size = size;
         this.angle = angle;
      }

      #region IConvexPolygonF Members
      /// <summary>
      /// Get the 4 verticies of this Box.
      /// </summary>
      /// <returns></returns>
      public System.Drawing.PointF[] GetVertices()
      {
         System.Drawing.PointF[] coordinates = new System.Drawing.PointF[4];
         CvInvoke.cvBoxPoints(this, coordinates);
         return coordinates;
      }

      #endregion

      /// <summary>
      /// Get the minimum enclosing rectangle for this Box
      /// </summary>
      /// <returns>The minimum enclosing rectangle for this Box</returns>
      public System.Drawing.Rectangle MinAreaRect()
      {
         float[] data = new float[8];
         CvInvoke.cvBoxPoints(this, data);
         int minX = (int)Math.Round(Math.Min(Math.Min(data[0], data[2]), Math.Min(data[4], data[6])));
         int maxX = (int)Math.Round(Math.Max(Math.Max(data[0], data[2]), Math.Max(data[4], data[6])));
         int minY = (int)Math.Round(Math.Min(Math.Min(data[1], data[3]), Math.Min(data[5], data[7])));
         int maxY = (int)Math.Round(Math.Max(Math.Max(data[1], data[3]), Math.Max(data[5], data[7])));
         return new System.Drawing.Rectangle(minX, minY, maxX - minX, maxY - minY);
      }
   }
}
