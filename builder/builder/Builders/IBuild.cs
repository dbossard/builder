using builder.Models;

namespace builder.Builders
{
    public interface IBuild
    {
        RegularizationRule Build();
    }
}