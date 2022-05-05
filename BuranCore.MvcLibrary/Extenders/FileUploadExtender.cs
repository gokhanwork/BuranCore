using Buran.Core.MvcLibrary.Resource;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Buran.Core.MvcLibrary.Extenders
{
    public static class FileUploadExtender
    {
        public static HtmlString FileUploader(this IHtmlHelper html, string name, string title, string imgPath, string uploadUrl, string cssClass = "btnFileUploader")
        {
            var div = $@"<div class='form-group' id='div{name}'>
    <label for='{name}' class='col-sm-3 control-label'>{title}</label>
    <div class='col-sm-8'>
        <img id='img{name}' src='{imgPath}' class='img-thumbnail img-fileupload'><br>
        <button type='button' class='{cssClass} btn btn-xs btn-default' id='btn{name}'>
            <i class='fa fa-upload'></i> {UI.Upload}
        </button>
        <input id='file{name}' type='file' name='file{name}' class='fileinput hide' data-url='{uploadUrl}'>
    </div>
</div>";
            return new HtmlString(div);
        }

        public static HtmlString FileUploaderNoImage(this IHtmlHelper html, string name, string title, string uploadUrl,
            string cssClass = "btnFileUploader", string fileCssClass = "fileinput",
            string labelCss = "col-sm-3", string editorCss = "col-sm-8", string buttonCss = "btn-xs")
        {
            var div = $@"<div class='form-group' id='div{name}'>
    <label for='{name}' class='{labelCss} control-label'>{title}</label>
    <div class='{editorCss}'>
        <button type='button' class='{cssClass} btn {buttonCss} btn-default' id='btn{name}'>
            <i class='fa fa-upload'></i> {UI.Upload}
        </button>
        <input id='file{name}' type='file' name='file{name}' class='{fileCssClass} hide' data-url='{uploadUrl}'>
    </div>
</div>";
            return new HtmlString(div);
        }

        public static long GetImageTempId()
        {
            return -1 * DateTime.Now.Ticks;
        }

        [Obsolete]
        public static HtmlString FileUploader2(this IHtmlHelper html, string name, string imgPath, string uploadUrl, string cssClass = "btnFileUploader")
        {
            var div = $@"<img id='img{name}' src='{imgPath}' class='img-thumbnail img-fileupload'><br>
        <button type='button' class='{cssClass} btn btn-xs btn-default' id='btn{name}'>
            <i class='fa fa-upload'></i> {UI.Upload}
        </button>
        <input id='file{name}' type='file' name='file{name}' class='fileinput hide' data-url='{uploadUrl}'>";
            return new HtmlString(div);
        }
    }
}