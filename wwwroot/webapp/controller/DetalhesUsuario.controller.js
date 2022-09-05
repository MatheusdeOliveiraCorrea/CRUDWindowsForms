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
			rotas.getRoute("RotadetalhesUsuario").attachPatternMatched(this._onObjectMatched, this);
		},	

		_onObjectMatched: function (oEvent)
		{
			var idUsuario = oEvent.getParameters().arguments.caminhoUsuario;
			let url =  `https://localhost:44351/api/users/${idUsuario}`;
			
			fetch(url, {method: "GET"})
			.then(response => response.json())
			.then(data => {
				data.dataNascimento = DateFormat.getDateInstance({ pattern: "dd-MM-yyyy" }).format(new Date(data.dataNascimento));
				data.dataCriacao = DateFormat.getDateInstance({ pattern: "dd-MM-yyyy" }).format(new Date(data.dataCriacao));
				if(data.dataNascimento == "31-12-1969") data.dataNascimento = null;

				this.getView().setModel(new JSONModel(data), "usuario")
			})
		},

		aoClicarEmVoltar: function () { rotas.navTo("RotaTelaPrincipal", {}, true); },

		aoClicarEmEditar: function(){
			var idUsuario = this.getView().getModel("usuario").oData.id;
			rotas.navTo("RotaEditarUsuario", {caminhoUsuario: idUsuario});
		},

		aoClicarEmDeletar: function(){

			if (!this.pDialog) {
				this.pDialog = this.loadFragment({
					name: "sap.ui.demo.walkthrough.view.DialogoDeletar"
				});
			} 
			this.pDialog.then(function(oDialog) { oDialog.open(); });
		},

		aoCancelarDialogo : function () {
			this.byId("DialogoDeletar").close();
		},

		aoDeletarUsuarioDialogo: function () {
			this.deletarUsuario(this.getView().getModel("usuario").oData.id);
			MessageToast.show("Usuário excluido com sucesso")
			this.byId("DialogoDeletar").close();
		},

		deletarUsuario: function(id){
			fetch(`https://localhost:44351/api/users/${id}`, {
				method: "DELETE",
			})
			.then(resp => { if(resp.ok) rotas.navTo("RotaTelaPrincipal"); })
		}

	});
});