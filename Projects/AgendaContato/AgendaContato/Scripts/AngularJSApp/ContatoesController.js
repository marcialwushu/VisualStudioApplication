//Seta o módulo para o AngularJS
var app = angular.module('app', []);

//Cria o controller contato

app.controller('ContatoesController', ['$scope', '$http', ContatoesController]);

//Método para o controller contato do AngujarJS

function ContatoesController($scope, $http) {

    //Declaração de variáveis
    $scope.exibeformNovoContato = false;
    $scope.ocultaTabelaListagemContato = false;
    $scope.exibeformAlterarContato = false;

    //Função para exibir o form para cadastro do novo contato
    $scope.funcformNovoContato = function () {
        $scope.exibeformNovoContato = true;
        $scope.ocultaTabelaListagemContato = true;
    };

    //Cadastrar contato
    $scope.cadastrarContato = function () {
        var dataAtual = new Date();
        this.novocontato.data_cadastro = dataAtual;
        $http.post('http://localhost:49467/api/Contatoes/PostContato', this.novocontato).success(function (data) {
            alert("Contato cadastrado com sucesso.");
            $scope.exibeformNovoContato = false;
            $scope.ocultaTabelaListagemContato = false;
            $scope.contato.push(data);
            $scope.novocontato = null;
        }).error(function (data) {
            $scope.error = "Erro ao cadastrar o contato! " + data;
        });
    };

    //Buscar listagem de contatos
    $http.get('http://localhost:49467/api/Contatoes/GetContato/').success(function (data) {
        $scope.contato = data;
    })
        .error(function () {
            $scope.error = "Erro ao carregar a listagem de clientes!";
        });

    //Função para exibir o form para cadastro do novo cliente
    $scope.funcformEditarContato = function () {
        $scope.contatoAlterar = this.contato;
        $scope.exibeformNovoContato = false;
        $scope.ocultaTabelaListagemContato = true;
        $scope.exibeformAlterarContato = true;
    };

}
