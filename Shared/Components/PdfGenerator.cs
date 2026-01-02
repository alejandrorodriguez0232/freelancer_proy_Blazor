using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using BlazorRegistroUsuarios.Data.Models;

namespace BlazorRegistroUsuarios.Shared.Components
{
    public class PdfGenerator
    {
        public byte[] GenerarReporteUsuarios(List<UsuarioRegistrador> usuarios)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .AlignCenter()
                        .Text("Reporte de Usuarios Registradores")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(col =>
                        {
                            col.Item().Text($"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                            col.Item().PaddingTop(10);

                            // Table of users
                            col.Item().Table(table =>
                            {
                                // Define columns
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Document
                                    columns.RelativeColumn(3); // Name
                                    columns.RelativeColumn(3); // Email
                                    columns.RelativeColumn(2); // Works
                                    columns.RelativeColumn(2); // Active
                                    columns.RelativeColumn(2); // Permission
                                    columns.RelativeColumn(2); // Registration Date
                                });

                                // Header
                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Documento");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Nombre");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Correo");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Trabaja");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Activo");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Permiso");
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Fecha Registro");
                                });

                                // Rows
                                foreach (var usuario in usuarios)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.NumeroDocumento);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.NombreCompleto);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Correo);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Trabaja ? "Sí" : "No");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Activo ? "Sí" : "No");
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Permiso);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.FechaRegistro.ToString("dd/MM/yyyy"));
                                }
                            });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Página ");
                            text.CurrentPageNumber();
                            text.Span(" de ");
                            text.TotalPages();
                        });
                });
            });

            return document.GeneratePdf();
        }

        public async Task<byte[]> GenerararPdf(IEnumerable<UsuarioRegistrador> usuarios)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .AlignCenter()
                        .Text("Reporte de Usuarios Registradores")
                        .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Item().Text($"Generado el: {DateTime.Now:dd/MM/yyyy HH:mm}")
                                .FontSize(10)
                                .FontColor(Colors.Grey.Medium);

                            column.Item().PaddingTop(10).Table(table =>
                            {
                                // Definir columnas
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2); // Nombres
                                    columns.RelativeColumn(2); // Apellidos
                                    columns.RelativeColumn(2); // Documento
                                    columns.RelativeColumn(3); // Correo
                                    columns.RelativeColumn(2); // Estado
                                });

                                // Encabezados
                                table.Header(header =>
                                {
                                    header.Cell().Background("#f5f5f5").Padding(5).Text("Nombres").SemiBold();
                                    header.Cell().Background("#f5f5f5").Padding(5).Text("Apellidos").SemiBold();
                                    header.Cell().Background("#f5f5f5").Padding(5).Text("Documento").SemiBold();
                                    header.Cell().Background("#f5f5f5").Padding(5).Text("Correo").SemiBold();
                                    header.Cell().Background("#f5f5f5").Padding(5).Text("Estado").SemiBold();

                                    header.Cell().ColumnSpan(5).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Grey.Lighten2);
                                });

                                // Datos
                                foreach (var usuario in usuarios)
                                {
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Nombres);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Apellidos);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.NumeroDocumento);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Correo);
                                    table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(usuario.Activo ? "Activo" : "Inactivo");
                                }
                            });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Página ");
                            x.CurrentPageNumber();
                            x.Span(" de ");
                            x.TotalPages();
                        });
                });
            });

            return document.GeneratePdf();
        }
    }
}