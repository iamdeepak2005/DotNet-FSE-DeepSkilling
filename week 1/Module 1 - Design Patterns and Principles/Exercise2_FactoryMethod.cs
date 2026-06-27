using System;

namespace DesignPatterns.FactoryMethod
{
    // document product interface
    public interface IDocument
    {
        void Open();
    }

    // concrete document classes
    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("opening a word doc (.docx)...");
    }

    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("opening a pdf file...");
    }

    public class ExcelDocument : IDocument
    {
        public void Open() => Console.WriteLine("opening an excel sheet...");
    }

    // abstract factory/creator
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    // factories for each document type
    public class WordFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new WordDocument();
    }

    public class PdfFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new PdfDocument();
    }

    public class ExcelFactory : DocumentFactory
    {
        public override IDocument CreateDocument() => new ExcelDocument();
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("--- factory method design pattern test ---");

            DocumentFactory factory = new PdfFactory();
            IDocument doc = factory.CreateDocument();
            doc.Open();

            DocumentFactory factory2 = new WordFactory();
            IDocument doc2 = factory2.CreateDocument();
            doc2.Open();
        }
    }
}