
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Alignment alignment2;

	private global::Gtk.Image image2;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Лавки Вику))");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.alignment2 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
		this.alignment2.Name = "alignment2";
		// Container child alignment2.Gtk.Container+ContainerChild
		this.image2 = new global::Gtk.Image();
		this.image2.Name = "image2";
		this.alignment2.Add(this.image2);
		this.Add(this.alignment2);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 330;
		this.DefaultHeight = 290;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}
}