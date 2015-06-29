public static class Extensions
{
	public static string RenderPartialViewToString(Controller thisController, string viewName, object model)
	{
		// Atribuir o modelo do controlador a partir do qual esse m�todo foi chamado para a inst�ncia do controlador passado (uma nova inst�ncia, por sinal)
			thisController.ViewData.Model = model;

		   // inicializando a string builder
		   using (StringWriter sw = new StringWriter())
			{
				 // Localizar e carregar partil view , pass�-lo atrav�s do controlador
				 ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(thisController.ControllerContext, viewName);
				 ViewContext viewContext = new ViewContext(thisController.ControllerContext, viewResult.View, thisController.ViewData, thisController.TempData, sw);

				 // renderizar
				  viewResult.View.Render(viewContext, sw);

				 //returnar a partial view como string
				 return sw.ToString();
			  }
		}
}