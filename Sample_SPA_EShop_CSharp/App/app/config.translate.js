define(['app'],function(app){
    app.config(['$translateProvider', function ($translateProvider) {
        $translateProvider.translations('fa', {
            'SAVE': 'ذخیره',
            'NEW': 'جدید',
            'NEW PRODUCT': 'محصول جدید',
            'TITLE': 'عنوان',
            'PRICE': 'قیمت'
        });

        $translateProvider.translations('de', {
            'SAVE': 'Hallo',
            'NEW': 'Dies ist ein Paragraph'
        });

        $translateProvider.preferredLanguage('fa');
    }]);
});
