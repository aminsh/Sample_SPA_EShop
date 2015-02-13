requirejs.config({
    baseUrl: '/app',
    urlArgs: 'v=1.0',
    paths: {
        'external': 'lib/external',
        'helper': 'lib/helper',
        'jQuery': 'lib/external/jquery-2.1.1.min',
        'angular': 'lib/external/angular.min',
        'angular-animate': 'lib/external/angular-animate.min',
        'angular-route': 'lib/external/angular-route.min',
        'angular-resource': 'lib/external/angular-resource.min',
        'angular-sanitize': 'lib/external/angular-sanitize.min',
        'linq': 'lib/external/linq.min',
        'helper-window': 'lib/helper/helper.window',
        'helper_array': 'lib/helper/helper.array',
        'breeze': 'lib/external/breeze.min',
        'Q': 'lib/external/q',
        'breezeHelper': 'lib/external/breeze.metadata-helper',
        'datajs': 'lib/external/datajs-1.0.3.min',
        'breeze-angular': 'lib/external/breeze.angular',
        'bootstrap': 'lib/external/bootstrap-rtl',
        'jayData': 'lib/external/jaydata',
        'jayDataFactory': 'service/jayDataFactory',
        'domReady': 'lib/helper/domReady',
        'contextOnReady': 'lib/helper/contextOnReady',
        'InMemoryProvider': 'lib/external/jaydataProviders/InMemoryProvider.min',
        'oDataProvider': 'lib/external/jaydataProviders/oDataProvider.min'
    },
    shim: {
        'jQuery': {
            exports: 'jQuery'
        },
        'angular': {
            deps: ['jQuery'],
            exports: 'angular'
        },
        'angular-animate': {
            deps: ['angular', 'jQuery'],
            exports: 'angular-animate'
        },
        'angular-route': {
            deps: ['angular'],
            exports: 'angular-route'
        },
        'angular-resource': {
            deps: ['angular'],
            exports: 'angular-resource'
        },
        'angular-sanitize': {
            deps: ['angular'],
            exports: 'angular-sanitize'
        },
        'Q': {
          exports: 'Q'
        },
        'breeze': {
          exports: 'breeze',
          deps: ['datajs','Q']
        },
        'breezeHelper': {
          exports: 'breezeHelper',
            deps: ['breeze']
        },
        'datajs': {
            exports: 'datajs'
        },
        'jayData': {
          exports: 'jayData',
            deps: ['datajs']
        },
        'jayDataFactory': {
            exports: 'jayDataFactory',
            deps: ['jayData','oDataProvider']
        },
        'breeze-angular': {
            exports: 'breeze-angular',
            deps: ['breeze', 'angular']
        },
        'bootstrap': {
          exports: 'bootstrap',
          deps: ['jQuery']
        },
        'linq': {exports: 'linq'},
        'helper-window': {deps: ['jQuery'], exports: 'helper-window'},
        'helper_array': {
            deps: ['linq'],
            exports: 'helper_array'
        },
        'app': {
            deps: ['angular'],
            exports: 'app'
        },
        'config.route': {
            deps: ['angular'],
            exports: 'config.route'
        },
        'domReady': {
            exports: 'domReady',
            deps: ['jQuery']
        },
        'contextOnReady': {
            exports: 'contextOnReady',
            deps: ['jayDataFactory']
        },
        'InMemoryProvider': { exports: 'InMemoryProvider', deps: ['jayData'] },
        'oDataProvider': {
            exports: 'oDataProvider', deps: ['InMemoryProvider']
        }
    }
});

require([
    'angular-animate',
    'angular-route',
    'angular-resource',
    'angular-sanitize',
    'helper-window',
    'helper_array',
    'app',
    'config.route',
    'controllers/shellController',
    'Q',
    'bootstrap',
    'directives/content',
    'domReady!',
    'contextOnReady!'
],
function() {
    angular.bootstrap(document, ['app']);

    var app = angular.module('app');
    app.register.controller('shell', controllers.shellController);
});