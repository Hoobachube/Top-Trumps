﻿namespace TopTrumps.Data.Helpers
{
    using DTOs;

    public interface ISqlHelper
    {
        string GetCardQuery(int id);

        string GetAllCardsQuery();

        string GetPlayersCollectionSql(string email);

        string GetCreateUsersSql();

        string GetAddUserToRoleSql(Role role);

        string CreateNewCardSql();

        string GetUpdateCardSql();

    }
}
