namespace LearnWebApi.Model.Mapper
{
    public interface IMapper<T, V>
    {
        public V Map(T data);
        public T Unmap(V data);
    }
}
