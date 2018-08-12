using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace NorhanXamarinTrainingService
{
    public class MyEntityTableSqlGenerator : EntityTableSqlGenerator
    {
        protected override void UpdateTableColumn(ColumnModel columnModel, TableColumnType tableColumnType)
        {
            //for system column deleted and created
            switch (tableColumnType)
            {
                case TableColumnType.Deleted:
                    columnModel.DefaultValue = 0;
                    break;
                case TableColumnType.UpdatedAt:
                    columnModel.DefaultValue = DateTime.Now;
                    break;
            }
            base.UpdateTableColumn(columnModel, tableColumnType);
        }

        //protected override void Generate(CreateTableOperation createTableOperation)
        //{
        //    foreach (ColumnModel column in createTableOperation.Columns)
        //    {
        //        TableColumnType tableColumnType = this.GetTableColumnType(column);
        //        if (tableColumnType == TableColumnType.None)
        //        {
        //            if (column.Annotations.Keys.Contains("DefaultValue"))
        //            {
        //                var value = Convert.ChangeType(column.Annotations["DefaultValue"].NewValue, column.ClrDefaultValue.GetType());
        //                column.DefaultValue = value;
        //            }
        //        }
        //    }
        //    base.Generate(createTableOperation);
        //}
    }
}