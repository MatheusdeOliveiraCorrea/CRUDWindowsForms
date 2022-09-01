sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"

], function (Controller, JSONModel, Filter, FilterOperator) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.UsuarioList", {

		onInit: function () {
			let rotas = this.getOwnerComponent().getRouter();
			rotas.getRoute("RotaTelaPrincipal").attachPatternMatched(this.pegarDadosBancoDeDados, this);
		},

		pegarDadosBancoDeDados : function (){
			let url = "https://localhost:44351/api/users";
			
			fetch(url, {method: "GET"})
			.then(response => response.json())
			.then(data => {
				let modelo = new JSONModel(data);
				this.getView().setModel(modelo, "usuarios")
			})
		},

		onFiltrarUsuarios: function (oEvent) {
			var resultadoDaQuery = [];
			var query = oEvent.getParameters().query;
			if (query) {
				var filtroNome = new Filter({
					filters: [

						new Filter({
							path: "nome",
							operator: FilterOperator.Contains,
							value1: query
						}),
						
						new Filter({
							path: "email",
							operator: FilterOperator.Contains,
							value1: query
						})

					]
				});
				resultadoDaQuery.push(filtroNome);
			}

			var listaDeUsuarios = this.byId("listaDeUsuarios");
			var oBinding = listaDeUsuarios.getBinding("items");
			oBinding.filter(resultadoDaQuery);
		},

		onClicarItemDaLista: function (oEvent) {
			var idUsuario = oEvent.getSource().getBindingContext("usuarios").getProperty("id");
			var oRouter = this.getOwnerComponent().getRouter();

			oRouter.navTo("RotadetalhesUsuario", {
				caminhoUsuario: idUsuario
			});
		},
		
		onClicarAdcionarUsuario: function(oEvent){
			var rotas = this.getOwnerComponent().getRouter();
			rotas.navTo("RotaAdcionarUsuario", {})
		}
	});
});