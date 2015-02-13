define(['app', 'jayData'], function(app, jdata){

    $data.Acorn = jdata;

    $data.Entity.extend('Product',{
        Id: {type: 'int', key: true},
        Name: {type: String},
        Price: {type: 'int'}
    });

    $data.Entity.extend('Category',{
        Id: {type: 'int', key: true},
        Name: {type: String}
    });

    $data.EntityContext.extend('eShopDatabase',{
        Products: {type: $data.EntitySet, elementType: Product},
        Categories: {type: $data.EntitySet, elementType: Category}
    });

    var context = new eShopDatabase({
        name: 'oData',
        oDataServiceHost: '/odata'
    });

    window.dataContext = context;
});