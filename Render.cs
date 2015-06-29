public static class Extensions
{
	public static string RenderPartialViewToString(Controller thisController, string viewName, object model)
	{
		// Atribuir o modelo do controlador a partir do qual esse método foi chamado para a instância do controlador passado (uma nova instância, por sinal)
			thisController.ViewData.Model = model;

		   // inicializando a string builder
		   using (StringWriter sw = new StringWriter())
			{
				 // Localizar e carregar partil view , passá-lo através do controlador
				 ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(thisController.ControllerContext, viewName);
				 ViewContext viewContext = new ViewContext(thisController.ControllerContext, viewResult.View, thisController.ViewData, thisController.TempData, sw);

				 // renderizar
				  viewResult.View.Render(viewContext, sw);

				 //returnar a partial view como string
				 return sw.ToString();
			  }
		}
}