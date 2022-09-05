sap.ui.define([
   "sap/ui/core/UIComponent",
   "sap/ui/model/json/JSONModel",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/Device"
], function (UIComponent, JSONModel, ResourceModel, Device) {
   "use strict";
   return UIComponent.extend("sap.ui.demo.walkthrough.Component", {
       metadata : {
           interfaces: ["sap.ui.core.IAsyncContentCreation"],
           manifest: "json"
     },
      init : function () {
         // call the init function of the parent
         UIComponent.prototype.init.apply(this, arguments);
         // set data model
         var oData = {
           recipient : {
           }
        };
        this.setModel(new JSONModel(oData));

         // set i18n model
         var i18nModel = new ResourceModel({
            bundleName: "sap.ui.demo.walkthrough.i18n.i18n"
         });
         this.setModel(i18nModel, "i18n");
         
         this.getRouter().initialize();
      },
      getContentDensityClass: function () {
			if (!this._sContentDensityClass) {
				if (!Device.support.touch) {
					this._sContentDensityClass = "sapUiSizeCompact";
				} else {
					this._sContentDensityClass = "sapUiSizeCozy";
				}
			}
			return this._sContentDensityClass;
		}
   });
});
