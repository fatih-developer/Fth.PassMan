namespace Core.Utilities.ActiveDirectory
{
    public interface ILdapTools
    {
        bool ValidateCredentials(string sUserName, string sPassword);
       
    }
}