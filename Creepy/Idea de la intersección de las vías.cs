/*
float x1 = inicio.Location.X;
float x2 = fin.Location.X;
float y1 = inicio.Location.Y;
float y2 = fin.Location.Y;
foreach (Railroad via in Vias){
	float x3 = via.Inicio.Tile.Location.X;
	float x4 = via.Fin.Tile.Location.X;
	float y3 = via.Inicio.Tile.Location.Y;
	float y4 = via.Fin.Tile.Location.Y;
	float numerador12 = (x4 - x3) * (y1 - y3) - (y4 - y3) * (x1 - x3);
	float numerador34 = (x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3);
	float denominador = (y4 - y3) * (x2 - x1) - (x4 - x3) * (y2 - y1);
	if (denominador != 0) //si las vias no son paralelas
	{
		float escalar12 = numerador12 / denominador;
		float escalar34 = numerador34 / denominador;
		if (0 <= escalar12 && escalar12 <= 1 && 0 <= escalar34 && escalar34 <= 1) //si la posible intersección está en ambos segmentos
		{
			//crear una vía desde el inicio hasta la intersección...
		}
	}
	else{
		if(numerador12==0) //creo que esto significa que las vías se superponen?
		{
			//crear nueva vía que sea la suma de la via que estamos chequeando y la via que estamos tratando de crear, luego borrar la vía vieja
		}
		else
		{
			//crear vía desde inicio hasta fin
		}
	}
}
*/