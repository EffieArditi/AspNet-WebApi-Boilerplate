// =========================================================
// Enums declaration
// =========================================================
var EnumName = {
    Zero: 0,
    One: 1,
};

// =========================================================
// Helper string functions
// =========================================================

function IsObjectNullOrUndefined(obj)
{
    return (typeof (obj) == 'undefined' || obj == null || obj == "");
}

// =========================================================
// localStorage functions
// =========================================================
function saveToStorage(name, value)
{
    if (typeof (Storage) !== "undefined")
    {
        localStorage.setItem(name, JSON.stringify(value));
    }
    else
    {
        console.error("Browser doen't support HTML5 localStorage");
    }
}

function loadFromStorage(name)
{
    if (typeof (Storage) !== "undefined")
    {
        var itemJson = localStorage.getItem(name);
        if (itemJson)
        {
            return JSON.parse(itemJson);
        }
    }
    else
    {
        console.log("Browser doen't support HTML5 localStorage");
    }

    return "";
}

function removeFromStorage(name)
{
    if (typeof (Storage) !== "undefined")
    {
        localStorage.removeItem(name);
    }
    else
    {
        console.log("Browser doen't support HTML5 localStorage");
    }
}

// =========================================================

// =========================================================
// Cookies handling functions
// =========================================================
function createCookie(name, value, days)
{
    var expires;
    if (days)
    {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    }

    else
    {
        expires = "";
    }

    document.cookie = name + "=" + value + expires + "; path=/";
};

function readCookie(name)
{
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++)
    {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
};

function deleteCookie(name)
{
    createCookie(name, "", -1);
};

// =========================================================
// HTML Helpers functions
// =========================================================
function GetOuterHtml(obj)
{
    return $(obj).clone().wrap('<div></div>').parent().html();
};