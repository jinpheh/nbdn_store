namespace nothinbutdotnetstore.infrastructure
{
    public interface MapperRegistry
    {
        Mapper<Input,Output> get_mapper_for<Input, Output>();
    }
}