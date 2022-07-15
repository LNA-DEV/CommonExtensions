using AutoMapper;

namespace CommonExtensions
{
    public static class Mapping
    {
        public static Output MapSimple<Output, Input>(this Input inputObject)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Input, Output>());
            var mapper = config.CreateMapper();

            var dashboard = mapper.Map<Output>(inputObject);

            return dashboard;
        }
    }
}
