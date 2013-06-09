using NGnono.Framework.Mapping.Engines;

namespace NGnono.Framework.Mapping
{
    public class EngineFactory
    {
        private IMappingEngine _engine;

        public EngineFactory()
        {
            _engine = new EmitMappingEngine();
        }

        public void SetEngine(IMappingEngine mappingEngine)
        {
            _engine = mappingEngine;
        }

        public IMappingEngine Create(string type)
        {
            return _engine;
        }
    }
}
