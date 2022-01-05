using System;

namespace DevIO.UI.Site.Services
{
    public class OperacaoService
    {
        
        public IOperacaoTransient Transient{ get; }
        public IOperacaoScoped Scoped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstace SingletonInstace { get; }

        public OperacaoService(IOperacaoTransient transient,
                               IOperacaoScoped scoped,
                               IOperacaoSingleton singleton,
                               IOperacaoSingletonInstace singletonInstace)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstace = singletonInstace;
        }
    }

    public class Operacao : IOperacaoTransient,
                            IOperacaoScoped,
                            IOperacaoSingleton,
                            IOperacaoSingletonInstace
    {
        public Guid OperacaoId { get; private set; }

        public Operacao() : this(Guid.NewGuid())
        {}

        public Operacao(Guid Id)
        {
            OperacaoId = Id;
        }
    }


    public interface IOperacao
    {
        Guid OperacaoId { get; }
    }
    
    public interface IOperacaoTransient : IOperacao
    {}
    public interface IOperacaoScoped : IOperacao
    {}
    public interface IOperacaoSingleton : IOperacao
    {}
    public interface IOperacaoSingletonInstace : IOperacao
    {}
}