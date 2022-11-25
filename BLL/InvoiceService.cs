using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InvoiceService
    {
        private readonly DataContext _context;

        public InvoiceService()
        {
            _context = new DataContext();
            _context.Database.EnsureCreated();
        }

        public ObjectResponse GuardarFactura(Invoice invoice)
        {
            try
            {
                var _invoice = _context.Invoice.Find(invoice.InvoiceNumber_);
                if (_invoice != null)
                {
                    if (invoice.InvoiceNumber_ <= Invoices().Objects.Count)
                    {
                        invoice.InvoiceNumber_ = ((Invoice)Invoices().Objects.LastOrDefault()).InvoiceNumber_ + 1;
                        return GuardarFactura(invoice);
                    }
                    return new ObjectResponse("Una factura no se puede registrar 2 veces o más.");
                }
                else
                {
                    _context.Invoice.Add(invoice);
                    _context.SaveChanges();
                    return new ObjectResponse(invoice);
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo validar la existencia de la factura. " + e.Message);
            }
        }

        public decimal MonthlyInvestment()
        {
            List<Invoice> Invoices = _context.Invoice.ToList();
            decimal inversion = 0;
            foreach (Invoice Invoice in Invoices)
            {
                if (Invoice.InvoiceDate_.ToString("MM/yyyy").Equals(DateTime.Now.ToString("MM/yyyy")))
                {
                    if (Invoice.Concept_.Equals("Compra"))
                    {
                        inversion += Invoice.Total_;
                    }

                }
            }

            return inversion;
        }

        public decimal MonthlyExpenditure()
        {
            List<Invoice> invoices = _context.Invoice.ToList();
            decimal expenses = 0;
            foreach (Invoice invoice in invoices)
            {
                if (invoice.InvoiceDate_.ToString("MM/yyyy").Equals(DateTime.Now.ToString("MM/yyyy")))
                {
                    if ((!invoice.Concept_.Equals("Compra") && !invoice.Concept_.Equals("Venta")))
                    {
                        expenses += invoice.Total_;
                    }

                }
            }

            return expenses;
        }

        public decimal MonthlyCost(string fecha)
        {
            List<Invoice> invoices = _context.Invoice.ToList();
            decimal inversion = 0;
            foreach (Invoice invoice in invoices)
            {
                if (invoice.InvoiceDate_.ToString("MM/yyyy").Equals(fecha))
                {
                    if (invoice.Concept_.Equals("Compra"))
                    {
                        inversion += invoice.Total_;
                    }

                }
            }

            return inversion;
        }

        public decimal MonthlyExpenditure(string fecha)
        {
            List<Invoice> invoices = _context.Invoice.ToList();
            decimal inversion = 0;
            foreach (Invoice invoice in invoices)
            {
                if (invoice.InvoiceDate_.ToString("MM/yyyy").Equals(fecha))
                {
                    if (invoice.Concept_.Equals("Pago de nomina"))
                    {
                        inversion += invoice.Total_;
                    }

                }
            }

            return inversion;
        }

        public decimal MonthlyIncome()
        {
            List<Invoice> invoices = _context.Invoice.ToList();
            decimal ganancia = 0;
            foreach (Invoice invoice in invoices)
            {
                if (invoice.Concept_.Equals("Venta"))

                {
                    if (invoice.InvoiceDate_.ToString("MM/yyyy").Equals(DateTime.Now.ToString("MM/yyyy")))
                    {
                       ganancia += invoice.Total_;
                    
                    }
                }
            }

            return ganancia;
        }

        public decimal MonthlyIncome(string fecha)
        {
            List<Invoice> invoices = _context.Invoice.ToList();
            decimal income = 0;
            foreach (Invoice invoice in invoices)
            {
                if (invoice.Concept_.Equals("Venta"))

                {
                    if (invoice.InvoiceDate_.ToString("MM/yyyy").Equals(fecha))
                    {
                        income += invoice.Total_;
                     
                    }
                }
            }

            return income;
        }


        public decimal NetIncome()
        {
            return MonthlyIncome() - MonthlyInvestment() - MonthlyExpenditure();
        }

        public decimal NetIncome(string Fecha)
        {

            return MonthlyIncome(Fecha) - MonthlyCost(Fecha) - MonthlyExpenditure(Fecha);
        }

        public ObjectResponse Invoices()
        {
            try
            {
                var invoice = _context.Invoice.ToList();
                if (invoice != null)
                {
                    return new ObjectResponse(invoice);
                }
                else
                {
                    return new ObjectResponse("No hay registro de facturas.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo acceder a la base de datos. " + e.Message);
            }
        }

        public ObjectResponse FindInvoiceByNumber(int numeroFactura)
        {
            try
            {
                var factura = _context.Invoice.Where(f => f.InvoiceNumber_.Equals(numeroFactura)).FirstOrDefault();
                if (factura != null)
                {
                    return new ObjectResponse(factura);
                }
                else
                {
                    return new ObjectResponse("No hay registro de facturas.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo acceder a la base de datos. " + e.Message);
            }
        }



        public ObjectResponse ModificarFactura(Invoice invoice)
        {
            try
            {
                var _factura = _context.Invoice.Find(invoice.InvoiceNumber_);
                if (_factura != null)
                {
                    _context.Invoice.Update(invoice);
                    _context.SaveChanges();
                    return new ObjectResponse(invoice);
                }
                else
                {
                    return new ObjectResponse("No existe el registro, no se puede modificar.");
                }
            }
            catch (System.Exception e)
            {

                return new ObjectResponse("No se pudo validar la existencia de la factura. " + e.Message);
            }
        }
        public decimal MounthlyGrowth()
        {
            decimal monthlyGrowth = 0;
            decimal cost = MonthlyCost(DateTime.Now.AddMonths(-1).ToString("MM/yyyy"));
            decimal Income = MonthlyIncome(DateTime.Now.AddMonths(-1).ToString("MM/yyyy"));
            
            decimal NetIncome =  Income - cost;
            if (NetIncome == 0)
            {
                monthlyGrowth = (this.NetIncome() - NetIncome) / 1;
            }
            else
            {
                monthlyGrowth = Math.Round(100 * ((this.NetIncome() - NetIncome) / Math.Abs(NetIncome)), 2);
            }

            return monthlyGrowth;
        }
    }
}
