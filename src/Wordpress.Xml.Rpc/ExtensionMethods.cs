using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    internal static class ExtensionMethods
    {
        public static string ToRPC(this PostStatus e)
        {
            switch (e)
            {
                case PostStatus.Any:
                    return "any";

                case PostStatus.AutoDraft:
                    return "pending";

                case PostStatus.Draft:
                    return "draft";

                case PostStatus.Future:
                    return "future";

                case PostStatus.Inherit:
                    return "inherit";

                case PostStatus.Pending:
                    return "pending";

                case PostStatus.Private:
                    return "private";

                case PostStatus.Published:
                    return "publish";

                case PostStatus.Trash:
                    return "trash";
            }

            throw new NotImplementedException();
        }

        public static string ToRPC(this Order e)
        {
            switch (e)
            {
                case Order.Ascending:
                    return "ascending";

                case Order.Descending:
                    return "descending";
            }

            throw new NotImplementedException();
        }

        public static string ToRPC(this PostOrderBy e)
        {
            switch (e)
            {
                case PostOrderBy.Author:
                    return "author";

                case PostOrderBy.Date:
                    return "date";

                case PostOrderBy.ID:
                    return "id";

                case PostOrderBy.Modified:
                    return "modified";

                case PostOrderBy.Name:
                    return "name";

                case PostOrderBy.None:
                    return "none";

                case PostOrderBy.Parent:
                    return "parent";

                case PostOrderBy.Random:
                    return "random";

                case PostOrderBy.Title:
                    return "title";

            }

            throw new NotImplementedException();
        }

        public static DateTime ToISO8601DateTime(this string date)
        {
            DateTime dateInst;
            DateTime8601.TryParseDateTime8601(date, out dateInst);

            return dateInst;
        }
    }
}
