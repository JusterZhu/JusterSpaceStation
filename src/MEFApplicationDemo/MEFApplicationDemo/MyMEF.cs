using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEFApplicationDemo;

public class MyMEF
{
    private void Init()
    {
        var catalog = new AggregateCatalog();
        catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyMEF).Assembly));
        var container = new CompositionContainer(catalog);
    }
}