sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/routing/History",
	"sap/ui/core/format/DateFormat",
	"sap/m/MessageToast"
], function (Controller, JSONModel, History, DateFormat, MessageToast) {
	"use strict";
	let usuarioCadastrar;
	let usuarioEditar;
	var rotaCadastrar = "";
	var rotaEditar = "";
	return Controller.extend("sap.ui.demo.walkthrough.controller.AdicionarUsuario",
		{
			onInit: function () {
				var oRouter = this.getOwnerComponent().getRouter();

				oRouter
					.getRoute("RotaAdcionarUsuario")
					.attachPatternMatched(this.rotaMatchedComAdicionarUsuario, this)

				oRouter
					.getRoute("RotaEditarUsuario")
					.attachPatternMatched(this.rotaMatchedComEditarUsuario, this)

				this.byId("campoDataNascimento").setMaxDate(new Date(Date.now()));
				this.byId("campoDataNascimento").setMinDate(new Date(1940,1,1));
			},

			rotaMatchedComAdicionarUsuario: function () {
				this.byId("campoNome").setValue("");
				this.byId("campoSenha").setValue("");
				this.byId("campoEmail").setValue("");
				this.byId("campoDataNascimento").setValue("");
				this.byId("campoDataCadastro").setValue("");

				usuarioCadastrar = {
					nome: "",
					email: "",
					senha: "",
					dataNascimento: "",
					dataCriacao: ""
				}

				const pattern = this.getOwnerComponent().getRouter().getHashChanger().getHash();
				rotaCadastrar = this.getOwnerComponent().getRouter().getRouteInfoByHash(pattern).name;
			},

			rotaMatchedComEditarUsuario: function (evento) {

				let idUsuario = evento.getParameter("arguments").caminhoUsuario;

				fetch(`https://localhost:44351/api/users/${idUsuario}`)
					.then(res => res.json())
					.then(data => {

						if(data.dataNascimento == null){
							this.byId("campoDataNascimento").setPlaceholder("Data não informada	");
						}else{
						data.dataNascimento = DateFormat.getDateInstance({ pattern: "yyyy-MM-dd" }).format(new Date(data.dataNascimento));
						}
						this.getView().setModel(new JSONModel(data), "usuario")

						usuarioEditar = {
							id: data.id,
							nome: "",
							email: "",
							senha: "",
							dataNascimento: "",
							dataCriacao: data.dataCriacao
						}

						const pattern = this.getOwnerComponent().getRouter().getHashChanger().getHash();
						rotaEditar = this.getOwnerComponent().getRouter().getRouteInfoByHash(pattern).name;
					});
			},

			onClicarVoltar: function () {
				var sPreviousHash = History.getInstance().getPreviousHash();
				if (sPreviousHash !== undefined) {
					window.history.go(-1);
				} else {
					var rotas = this.getOwnerComponent().getRouter();
					rotas.navTo("RotaTelaPrincipal")
				}
			},

			validarData: function (data) {
				return !data.isValidValue() ? false : true; 
			},

			aoClicarEmSalvar: function () {
				const pattern = this.getOwnerComponent().getRouter().getHashChanger().getHash();
				var nomeDaRotaAtual = this.getOwnerComponent().getRouter().getRouteInfoByHash(pattern).name;

				var nomeInserido = this.byId("campoNome").getValue();
				var emailInserido = this.byId("campoEmail").getValue();
				var senhaInserida = this.byId("campoSenha").getValue();
				var dataNascimentoInserida = this.byId("campoDataNascimento");

				var camposValidosTelaAdicionar =
					this.validarNome(nomeInserido) &&
					this.validarSenha(senhaInserida) &&
					this.validarEmail(emailInserido) && 
					this.validarData(dataNascimentoInserida);

				if(!this.validarData(dataNascimentoInserida)){MessageToast.show("DATA INVÁLIDA");}

				if (nomeDaRotaAtual == rotaCadastrar && camposValidosTelaAdicionar) {
					var dataCriacaoFormatada = DateFormat.getDateInstance({ pattern: "yyyy-MM-dd" }).format(new Date(Date.now()));

					usuarioCadastrar.nome = nomeInserido;
					usuarioCadastrar.email = emailInserido;
					usuarioCadastrar.senha = senhaInserida;
					usuarioCadastrar.dataNascimento = dataNascimentoInserida.getValue() || null;
					usuarioCadastrar.dataCriacao = dataCriacaoFormatada;

					this.adicionarUsuario(usuarioCadastrar);
					MessageToast.show("Usuário Adcionado ... ");
					this.rotaMatchedComAdicionarUsuario();
				}

				var camposValidosTelaEditar = 
				this.validarNome(nomeInserido) &&
				this.validarEmail(emailInserido) &&
				this.validarSenha(senhaInserida) &&
				this.validarData(dataNascimentoInserida);
				
				if (nomeDaRotaAtual == rotaEditar && camposValidosTelaEditar) {

					if(!this.validarData(dataNascimentoInserida)){MessageToast.show("DATA INVÁLIDA"); }
					usuarioEditar.nome = nomeInserido;
					usuarioEditar.email = emailInserido;
					usuarioEditar.senha = senhaInserida;

					usuarioEditar.dataNascimento =  dataNascimentoInserida != "" ? dataNascimentoInserida.getValue() : null;
					
					this.editarUsuario(usuarioEditar);
				}
			},

			validarEmail: function (valor) {

				if (valor.length >= 5) {

					var regex = /^\w+[\w-+\.]*\@\w+([-\.]\w+)*\.[a-zA-Z]{2,}$/;
					if (!valor.match(regex)) {
						MessageToast.show("Você deve inserir um email válido..." + "  " + valor + "  não é um email válido.");
						return false;
					}
					return true;
				} else {
					MessageToast.show("Você deve inserir um email com no mínimo 5 caracteres")
				}
			},

			validarSenha: function (senha) {
				if (senha.length < 5) {
					MessageToast.show("A senha não pode ser vazia e deve possuir no mínimo 5 caracteres");
					return false;
				}
				return true;
			},

			validarNome: function (nome) {

				if (nome.length < 2) {
					MessageToast.show("O nome não pode ser vazio e deve possuir no mínimo 2 caracteres");
					return false;
				}
				return true;
			},

			adicionarUsuario: function (usuario) {
				fetch("https://localhost:44351/api/users", {
					method: "POST",
					body: JSON.stringify(usuario),
					headers: {
						"Content-Type": "application/json",
					}
				})
					.then((resp) => { 
						if(resp.ok){}
						else {
							resp.json().then(data => {
								if(data.value)
									data.value.forEach(element => { 
										console.log(element.errorMessage) 
									});
					})
						}
					})
			},

			onClicarCancelar: function(oEvent){
				const pattern = this.getOwnerComponent().getRouter().getHashChanger().getHash();
				var nomeDaRotaAtual = this.getOwnerComponent().getRouter().getRouteInfoByHash(pattern).name;

				if(nomeDaRotaAtual == rotaCadastrar){
					var rotas = this.getOwnerComponent().getRouter();
					rotas.navTo("RotaTelaPrincipal")
				}

				if(nomeDaRotaAtual == rotaEditar){
					var rotas = this.getOwnerComponent().getRouter();
					var idUsuario = this.getView().getModel("usuario").oData.id;
					rotas.navTo("RotadetalhesUsuario", {caminhoUsuario: idUsuario })
				}
			},

			editarUsuario: function (usuario) {

				fetch("https://localhost:44351/api/users", {
					method: "PATCH",
					body: JSON.stringify(usuario),
					headers: {
						"Content-Type": "application/json",
					}
				})
					.then((resp) => { 
						if(resp.ok){
							var oRouter = this.getOwnerComponent().getRouter();
							oRouter.navTo("RotadetalhesUsuario" , { caminhoUsuario: usuario.id })
						}else{
							resp.json().then(data => {
								MessageToast.show(data.value[0].errorMessage);
							})
						}
					})
			}
		});
}); 