sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"

], function (Controller, JSONModel, Filter, FilterOperator) {
	"use strict";

	return Controller.extend("sap.ui.demo.walkthrough.controller.UsuarioList", {

		onInit: function () {
			this._sContentDensityClass = "sapUiSizeCozy";
			let rotas = this.getOwnerComponent().getRouter();
			rotas.getRoute("RotaTelaPrincipal").attachPatternMatched(this.pegarDadosBancoDeDados, this);
		},

		pegarDadosBancoDeDados: function () {
			let url = "https://localhost:44351/api/users";

			fetch(url, { method: "GET" })
				.then(response => response.json())
				.then(data => {
					this.getView().setModel(new JSONModel(data), "usuarios")
				})
		},

		aoPesquisarUsuario: function (oEvent) {
			let parametros = oEvent.getParameters();

			var query = parametros.query || parametros.newValue;
			if (query) {
				let url = `https://localhost:44351/api/users/pesquisa/${query}`;

				fetch(url, { method: "GET" })
					.then(response => response.json())
					.then(data => {
						var modeloUsuarios = this.getView().getModel("usuarios");
						var modeloUsuariosAtualizado = this.getView().setModel(new JSONModel(data), "usuarios");
						modeloUsuarios = modeloUsuariosAtualizado;
					})
			}
			if(query == "")	this.pegarDadosBancoDeDados();
		},

		aoClicarNoUsuario: function (oEvent) {
			var idUsuario = oEvent.getSource().getBindingContext("usuarios").getProperty("id");
			var oRouter = this.getOwnerComponent().getRouter();

			oRouter.navTo("RotadetalhesUsuario", { caminhoUsuario: idUsuario });
		},

		aoClicarAdicionarUsuario: function (oEvent) {
			var rotas = this.getOwnerComponent().getRouter();
			rotas.navTo("RotaAdcionarUsuario", {})
		}
	});
});