using System;
using System.Collections.ObjectModel;

public class Response<T>
{
    public string status;
    public int lenght;
    public ObservableCollection<T> data;
	public Response()
	{

	}

}
