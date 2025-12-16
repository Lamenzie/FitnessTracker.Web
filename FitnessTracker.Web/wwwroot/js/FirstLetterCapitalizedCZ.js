(function () {
    function register() {
        if (!window.jQuery || !$.validator || !$.validator.unobtrusive) {
            // ještě nejsou načtené knihovny => zkusíme znovu za chvíli
            setTimeout(register, 50);
            return;
        }

        // 1) metoda validace
        $.validator.addMethod("firstlettercapitalizedcz", function (value, element) {
            if (!value) return true;

            value = value.trim();
            if (value.length === 0) return true;

            var firstChar = value.charAt(0);
            return firstChar === firstChar.toUpperCase();
        });

        // 2) adapter pro unobtrusive
        $.validator.unobtrusive.adapters.addBool("firstlettercapitalizedcz");

        // 3) KLÍČ: přepársuj formuláře po registraci pravidla
        $.validator.unobtrusive.parse(document);

        console.log("✅ firstlettercapitalizedcz registered + parsed");
    }

    register();
})();
