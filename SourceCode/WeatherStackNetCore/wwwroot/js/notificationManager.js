//Look documentation for more detail http://lobianijs.com/site/lobibox#lobibox-notification-usage
var MyBookShelfWeb = MyBookShelfWeb || {};


MyBookShelfWeb.notification = {

    ShowErrorMessage: function (title,message) {
        Lobibox.notify('error', {
            title:title,
            msg: message
        });
    },
    
    ShowOKMessage: function (title, message) {
        Lobibox.notify('success', {
            title: title,
            msg: message
        });
    },

    ShowInfoMessage: function (title, message) {
        Lobibox.notify('info', {
            title: title,
            msg: message
        });
    },

    ShowWarningMessage: function (title, message) {
        Lobibox.notify('warning', {
            title: title,
            msg: message
        });
    }
}
