﻿using Buran.Core.MvcLibrary.Grid;
using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Buran.Core.MvcLibrary.Grid4
{
    public class DataGridOptions4
    {
        public DataGridOptions4()
        {
            TableId = "";
            var popupEditorCss = "fancybox fancybox.iframe";

            CssTable = "dataGrid table table-striped table-bordered";
            EmptyData = "<div>EMPTY RESULT</div>";

            ShowHeader = true;

            Sortable = true;
            SortDirKeyword = "sortdir";
            SortKeyword = "sort";
            SortDefaultDirection = "ASC";

            PagerAndShortAction = "ListView";
            PagerJsFunction = "LoadGrid";
            GridDiv = "divList";
            PagerKeyword = "pageindex";
            PageSizeKeyword = "pagesize";
            PagerEnabled = true;

            ButtonDeleteEnabled = false;
            ButtonDeleteAction = "delete";
            ButtonDeleteCss = "btn btn-sm btn-danger";

            ButtonEditEnabled = true;
            ButtonEditAction = "edit";
            EditPopup = false;
            ButtonEditCss = "btn btn-sm btn-default";
            ButtonEditPopupCss = ButtonEditCss + " " + popupEditorCss;

            ButtonInsertAction = "create";
            ButtonInsertEnabled = false;
            InsertPopup = false;
            ButtonInsertCss = "btn btn-sm btn-link";
            ButtonInsertPopupCss = ButtonInsertCss + " " + popupEditorCss;

            ButtonShowOpenNew = false;
            ButtonShowEnabled = false;
            ButtonShowAction = "show";
            ButtonShowCss = "btn btn-sm btn-default";

            ButtonColumnWidth = 75;

            Buttons = new List<HtmlString>();
            HeaderButtons = new List<HtmlString>();
            FilteringEnabled = true;

            Popup = "";
            PopupSize = new Size(700, 450);

            RowOtherButtons = new List<HtmlString>();
            RowOtherButtonsCss = "btn btn-sm";

            ButtonRefreshEnabled = true;
            ButtonRefreshCss = "btn btn-sm btn-link";

            PageSizeList = new List<int> { 25, 50, 100 };
            DefaultPageSize = 25;
            PagerLocation = PagerLocationTypes.Bottom;

            DefaultSorting = true;

            Responsive = true;
        }

        public string CssTable { get; set; }
        public string TableId { get; set; }
        public bool ShowHeader { get; set; }
        public bool DefaultSorting { get; set; }

        public string PagerAndShortAction { get; set; }
        public string PagerJsFunction { get; set; }
        public string GridDiv { get; set; }

        public string PagerKeyword { get; set; }
        public string PageSizeKeyword { get; set; }
        public bool PagerEnabled { get; set; }

        public bool Sortable { get; set; }
        public string SortKeyword { get; set; }
        public string SortDirKeyword { get; set; }
        public string SortDefaultFieldName { get; set; }
        public string SortDefaultDirection { get; set; }

        public bool ButtonInsertEnabled { get; set; }
        public string ButtonInsertAction { get; set; }
        public string ButtonInsertCss { get; set; }
        public string ButtonInsertPopupCss { get; set; }
        public bool InsertPopup { get; set; }

        public bool ButtonRefreshEnabled { get; set; }
        public string ButtonRefreshCss { get; set; }

        public bool ButtonEditEnabled { get; set; }
        public string ButtonEditAction { get; set; }
        public string ButtonEditCss { get; set; }
        public bool EditPopup { get; set; }
        public string ButtonEditPopupCss { get; set; }

        public bool ButtonDeleteEnabled { get; set; }
        public string ButtonDeleteAction { get; set; }
        public string ButtonDeleteCss { get; set; }

        public bool ButtonShowOpenNew { get; set; }
        public bool ButtonShowEnabled { get; set; }
        public string ButtonShowAction { get; set; }
        public string ButtonShowCss { get; set; }


        public int ButtonColumnWidth { get; set; }
        public List<HtmlString> Buttons { get; set; }
        public List<HtmlString> HeaderButtons { get; set; }

        public string KeyField { get; set; }
        public string TextField { get; set; }
        public bool FilteringEnabled { get; set; }

        public string EmptyData { get; set; }



        public string Popup { get; set; }
        public Size PopupSize { get; set; }



        public List<HtmlString> RowOtherButtons { get; set; }
        public string RowOtherButtonsCss { get; set; }



        public string ButtonEditShowFunc { get; set; }
        public string ButtonDeleteShowFunction { get; set; }
        public string RowBackCssClassFunc { get; set; }
        public Type RowBackFormatter { get; set; }



        public List<int> PageSizeList { get; set; }
        public int DefaultPageSize { get; set; }
        public PagerLocationTypes PagerLocation { get; set; }


        public bool Responsive { get; set; }
    }
}
