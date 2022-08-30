sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageToast",
	"sap/ui/core/format/DateFormat"
], function (Controller, JSONModel, MessageToast, DateFormat ) {	
	"use strict";

	var rotas;
	return Controller.extend("sap.ui.demo.walkthrough.controller.DetalhesUsuario", 
	{
		onInit: function () 
		{
			 
			rotas = this.getOwnerComponent().getRouter();
			rotas
				.getRoute("RotadetalhesUsuario")
				.attachPatternMatched(this._onObjectMatched, this);
		},	

		_onObjectMatched: function (oEvent)
		{
			var idUsuario = oEvent.getParameters().arguments.caminhoUsuario;
			let url =  `https://localhost:44351/api/users/${idUsuario}`;
			
			fetch(url, {method: "GET"})
			.then(response => response.json())
			.then(data => {
				let modelo = new JSONModel(data);
				this.getView().setModel(modelo, "usuario")

				var dataNascimentoFormatada = DateFormat.getDateInstance({ pattern: "yyyy-MM-dd" }).format(new Date(this.getView().getModel("usuario").oData.dataNascimento));
				console.log(dataNascimentoFormatada);
				data.dataNascimento = DateFormat.getDateInstance({ pattern: "yyyy-MM-dd" }).format(new Date());
			})
		},
		onClicarVoltar: function () { rotas.navTo("RotaTelaPrincipal", {}, true); },

		onBotaoEditar: function(){
			var idUsuario = this.getView().getModel("usuario").oData.id;
			rotas.navTo("RotaEditarUsuario", {caminhoUsuario: idUsuario});
		},

		onBotaoDeletar: function(){

			if (!this.pDialog) {
				this.pDialog = this.loadFragment({
					name: "sap.ui.demo.walkthrough.view.DialogoDeletar"
				});
			} 
			this.pDialog.then(function(oDialog) { oDialog.open(); });
		},
		onCancelarDialogo : function () {
			this.byId("DialogoDeletar").close();
			rotaTelaAtual.navTo("RotaTelaPrincipal", {}, true);
		},
		onDeletarUsuarioDialogo: function () {
			this.deletarUsuario(this.getView().getModel("usuario").oData.id);
			MessageToast.show("Usuário excluido com sucesso")
			this.byId("DialogoDeletar").close();
		},
		deletarUsuario: function(id){
			fetch("https://localhost:44351/api/users/" + id, {
				method: "DELETE",
			})
			.then(resp => { if(resp.ok) rotas.navTo("RotaTelaPrincipal"); })
		}
	});
});