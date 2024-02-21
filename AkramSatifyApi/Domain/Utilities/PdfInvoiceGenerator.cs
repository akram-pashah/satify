using Domain.Entities;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities
{
    public class PdfInvoiceGenerator
    {
        public MemoryStream GenerateInvoice(Order order)
        {
            PdfDocument document = new();

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont titleFont = new("Arial", 18, XFontStyleEx.Bold);
            XFont subtitleFont = new("Arial", 14, XFontStyleEx.Bold);
            XFont regularFont = new("Arial", 12, XFontStyleEx.Regular);

            gfx.DrawString("Invoice", titleFont, XBrushes.Black, new XPoint(50, 50));

            gfx.DrawString($"Order ID: {order.Id}", subtitleFont, XBrushes.Black, new XPoint(50, 100));
            gfx.DrawString($"Ordered On: {order.OrderedOn}", subtitleFont, XBrushes.Black, new XPoint(50, 130));

            gfx.DrawString("Shipping Address:", subtitleFont, XBrushes.Black, new XPoint(50, 180));
            gfx.DrawString($"{order.Address.Street}", regularFont, XBrushes.Black, new XPoint(50, 210));
            gfx.DrawString($"{order.Address.Area}", regularFont, XBrushes.Black, new XPoint(50, 230));
            gfx.DrawString($"{order.Address.City}, {order.Address.State} {order.Address.ZipCode}", regularFont, XBrushes.Black, new XPoint(50, 250));
            gfx.DrawString($"{order.Address.Country}", regularFont, XBrushes.Black, new XPoint(50, 270));

            var sellerAddress = order.Seller.Addresses.First();
            gfx.DrawString("Seller Address:", subtitleFont, XBrushes.Black, new XPoint(400, 180));
            gfx.DrawString($"{sellerAddress.Street}", regularFont, XBrushes.Black, new XPoint(400, 210));
            gfx.DrawString($"{sellerAddress.Area}", regularFont, XBrushes.Black, new XPoint(400, 230));
            gfx.DrawString($"{sellerAddress.City}, {sellerAddress.State} {sellerAddress.ZipCode}", regularFont, XBrushes.Black, new XPoint(400, 250));
            gfx.DrawString($"{sellerAddress.Country}", regularFont, XBrushes.Black, new XPoint(400, 270));

            int yOffset = 350;
            foreach (var orderItem in order.OrderItems)
            {
                gfx.DrawString($"Product: {orderItem.Product.ProductName}", subtitleFont, XBrushes.Black, new XPoint(50, yOffset));
                gfx.DrawString($"Price: {orderItem.Product.ProductPrice}", regularFont, XBrushes.Black, new XPoint(200, yOffset));
                gfx.DrawString($"Quantity: {orderItem.Quantity}", regularFont, XBrushes.Black, new XPoint(350, yOffset));

                yOffset += 30;
            }

            gfx.DrawString($"Total Amount: {order.TotalAmount}", subtitleFont, XBrushes.Black, new XPoint(50, yOffset + 50));

            MemoryStream stream = new();
            document.Save(stream, false);
            stream.Position = 0;

            return stream;
        }
    }
}
