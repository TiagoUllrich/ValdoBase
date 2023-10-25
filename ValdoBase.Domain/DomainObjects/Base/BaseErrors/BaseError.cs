namespace ValdoBase.Domain.DomainObjects.Base.BaseErrors
{
    public abstract class BaseError
    {
        private List<string> _errors;

        public BaseError()
            => _errors = new List<string>();

        public virtual void AddError(string erro)
        {
            _errors = _errors ?? new List<string>();
            _errors.Add(erro);
        }

        public virtual void AddError(IEnumerable<string> errors)
        {
            errors ??= new List<string>();

            foreach (string error in errors)
            {
                AddError(error);
            }
        }

        public virtual void AddError(BaseError baseError)
        {
            AddError(baseError?.GetErrors());
        }

        public virtual void AddError(IEnumerable<BaseError> baseErrors)
        {
            baseErrors?.ToList().ForEach(delegate (BaseError x)
            {
                AddError(x);
            });
        }

        public virtual List<string> GetErrors()
        {
            return _errors;
        }

        public virtual bool IsValid()
        {
            if (_errors == null)
            {
                return false;
            }

            return !_errors.Any();
        }
    }
}