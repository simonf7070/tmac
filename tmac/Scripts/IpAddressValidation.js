$.validator.unobtrusive.adapters.addBool("ipaddress");

$.validator.addMethod("ipaddress", function (value) {
    return tmac.isValidIpAddress(value);
});


var tmac = (function (window, undefined) {

    function isValidIpAddress(value) {
        if (value) {
            var ipAddressParts = value.split('.');
            if (ipAddressParts.length != 4) {
                return false;
            }
            for (var i = 0; i < ipAddressParts.length; i++) {
                var num = parseInt(ipAddressParts[i], 10);
                if ($.isNumeric(num)) {
                    if (num < 0 || num > 255) {
                        return false;
                    }
                } else {
                    return false;
                }
            }
        }
        return true;
    }

    return {
        isValidIpAddress: isValidIpAddress
    };
})(window);