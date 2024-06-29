namespace API.Services;

public class PaginacaoService
{
public class ListaPaginada<T>
{
    public List<T> Items { get; private set; }
    public int PaginasIndex { get; private set; }
    public int PaginasTotais { get; private set; }
    public int ContagemTotal { get; private set; }

    public ListaPaginada(List<T> items, int contagem, int paginaIndex, int paginaTamanho)
    {
        Items = items;
        ContagemTotal = contagem;
        PaginasIndex = paginaIndex;
        PaginasTotais = (int)Math.Ceiling(contagem / (double)paginaTamanho);
    }

    public bool TemPaginaAnterior => PaginasIndex > 1;
    public bool TemPaginaSeguinte => PaginasIndex < PaginasTotais;
}
}
