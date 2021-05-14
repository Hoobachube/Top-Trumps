namespace TopTrumps.Data.Helpers
{
    using DTOs;

    public interface ISqlHelper
    {
        string GetAllCardsQuery();

        string GetCollectionSql(string email);

        string GetCreateUsersSql();

        string GetAddUserToRoleSql(Role role);
    }
}
