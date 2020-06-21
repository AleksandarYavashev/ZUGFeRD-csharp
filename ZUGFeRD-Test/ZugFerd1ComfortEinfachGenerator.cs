﻿using s2industries.ZUGFeRD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ZUGFeRD_Test
{
    internal class ZugFerdComfortEinfachGenerator
    {
        public void generate()
        {
            string filename = "ZUGFeRD_1p0_COMFORT_Einfach.xml";

            InvoiceDescriptor desc = _generateDescriptor();
            desc.Save(filename);
        } // !generate()


        private InvoiceDescriptor _generateDescriptor()
        { 
            InvoiceDescriptor desc = InvoiceDescriptor.CreateInvoice("471102", new DateTime(2013, 6, 5), CurrencyCodes.EUR, "2013-471102");
            desc.Profile = Profile.Comfort;
            desc.AddNote("Rechnung gemäß Bestellung vom 01.03.2013.");

            StringBuilder lieferantNote = new StringBuilder();
            lieferantNote.AppendLine("Lieferant GmbH");
            lieferantNote.AppendLine("Lieferantenstraße 20");
            lieferantNote.AppendLine("80333 München");
            lieferantNote.AppendLine("Deutschland");
            lieferantNote.AppendLine("Geschäftsführer: Hans Muster");
            lieferantNote.AppendLine("Handelsregisternummer: H A 123");
            desc.AddNote(lieferantNote.ToString(), SubjectCodes.REG);

            desc.SetSeller("Lieferant GmbH",
                           "80333",
                           "München",
                           "Lieferantenstraße 20",
                           CountryCodes.DE,
                           "",
                           new GlobalID(GlobalID.SchemeID_GLN, "4000001123452"));
            desc.AddSellerTaxRegistration("201/113/40209", TaxRegistrationSchemeID.FC);
            desc.AddSellerTaxRegistration("DE123456789", TaxRegistrationSchemeID.VA);

            desc.SetBuyer("Kunden AG Mitte",
                          "69876",
                          "Frankfurt",
                          "Kundenstraße 15",
                          CountryCodes.DE,
                          "GE2020211",
                          new GlobalID(GlobalID.SchemeID_GLN, "4000001987658"));
            desc.SetBuyerContact("Hans Muster");

            desc.ActualDeliveryDate = new DateTime(2013, 03, 05);
            desc.setPaymentMeans(PaymentMeansTypeCodes.PaymentMeans_31, "Überweisung");
            desc.addCreditorFinancialAccount("DE08700901001234567890", "GENODEF1M04");
            desc.AddApplicableTradeTax(275.0m, 7.0m, TaxTypes.VAT, TaxCategoryCodes.S);
            desc.AddApplicableTradeTax(198.00m, 19.0m, TaxTypes.VAT, TaxCategoryCodes.S);
            desc.SetTradePaymentTerms("Zahlbar innerhalb 30 Tagen netto bis 04.04.2013, 3% Skonto innerhalb 10 Tagen bis 15.03.2013",
                                      new DateTime(2013, 4, 4));
            desc.SetTotals(473.00m,
                           0.00m,
                           0.00m,
                           473.00m,
                           56.87m,
                           529.87m,
                           0.00m,
                           529.87m);
            desc.addTradeLineItem(name: "Trennblätter A4",
                                  unitCode: QuantityCodes.C62,
                                  grossUnitPrice: 9.90m,
                                  netUnitPrice: 9.90m,
                                  billedQuantity: 20m,
                                  taxType: TaxTypes.VAT,
                                  categoryCode: TaxCategoryCodes.S,
                                  taxPercent: 19.00m,
                                  id: new GlobalID(GlobalID.SchemeID_EAN, "4012345001235"),
                                  sellerAssignedID: "TB100A4");

            desc.addTradeLineItem(name: "Joghurt Banane",
                                  unitCode: QuantityCodes.C62,
                                  grossUnitPrice: 5.50m,
                                  netUnitPrice: 5.50m,
                                  billedQuantity: 50m,
                                  taxType: TaxTypes.VAT,
                                  categoryCode: TaxCategoryCodes.S,
                                  taxPercent: 7.00m,
                                  id: new GlobalID(GlobalID.SchemeID_EAN, "4000050986428"),
                                  sellerAssignedID: "ARNR2");

            return desc;
        } // !_generateDescriptor()


        public void read()
        {
            InvoiceDescriptor tempDesc = _generateDescriptor();
            MemoryStream ms = new MemoryStream();
            tempDesc.Save(ms);
            string  s = Encoding.ASCII.GetString(ms.ToArray());
            InvoiceDescriptor desc = InvoiceDescriptor.Load(ms);

            bool equals = tempDesc.Equals(desc);
        } // !read()
    }
}
