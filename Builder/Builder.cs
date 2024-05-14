namespace Builder
{
    public abstract class Builder<T> where T : class
    {
        protected Builder() { }
        public abstract T Build();
    }
}
