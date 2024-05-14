using Builder;

namespace BuilderFrontend
{
    public class BuilderHtml
    {
        public BuilderHtml()
        {
        }

        public string Build(Product product)
        {
            return $@"
                <html>
                    <head>
                        <meta charset='UTF-8'/>
                    </head>
                    <body style='font-family:Open Sans; color:#333333'>
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <table border='0' cellpadding='1' cellspacing='1' style='width: 100%;'>
                                            <tbody>
                                                <tr>
                                                    <td style='font-size: 12px; width: 25%; letter-spacing: 0.15px; padding-top: 16px;'><strong>Product</strong></td>
                                                    <td style='font-size: 12px; width: 30%; letter-spacing: 0.15px; padding-top: 16px;'><strong>Brand</strong></td>                        
                                                    <td style='font-size: 12px; width: 33%; letter-spacing: 0.15px; padding-top: 16px;'><strong>Avaliable</strong></td>
                                                    <td style='font-size: 12px; width: 12%; letter-spacing: 0.15px; padding-top: 16px;'><strong>Total</strong></td>                        
                                                </tr>
                                                <tr>
                                                    <td style='font-size: 12px; width: 25%; letter-spacing: 0.4px; padding-top: 8px; padding-bottom: 16px;'>{product.Name}</td> 
                                                    <td style='font-size: 12px; width: 30%; letter-spacing: 0.4px; padding-top: 8px; padding-bottom: 16px;'>{product.Brand}</td> 
                                                    <td style='font-size: 12px; width: 33%; letter-spacing: 0.4px; padding-top: 8px; padding-bottom: 16px;'>{product.Available()}</td> 
                                                    <td style='font-size: 12px; width: 12%; letter-spacing: 0.4px; padding-top: 8px; padding-bottom: 16px;'><strong>{product.Total()}</strong></td> 
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </body>
                </html>";
        }
    }
}
