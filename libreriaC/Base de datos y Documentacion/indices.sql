create unique index indice_Autor on Autor(Id_Autor)
create unique index indice_AutorNombre on Autor(Nombre,Apellido,Fecha_Nacimiento)
create unique index indice_CategoriaNombre on Categoria(Nombre)
create unique index indice_CategoriaId on Categoria(Id_Categoria)
create unique index indice_Ciudad on Ciudad(Id_Ciudad)
create unique index indice_Departamento on Departamento(Id_Departamento)
create unique index indice_DepartamentoNombre on Departamento(Departamento)
create unique index indice_DescuentoPorcentaje on Descuento(Porcentaje)
create unique index indice_Descuento on Descuento(Id_Descuento)
create unique index indice_Detalle_Venta on Detalle_Venta(Id_Detalle)
create unique index indice_Editorial on Editorial(Id_Editorial)
create unique index indice_Estado on Estado(Id_Estado)
create unique index indice_Libro on Libro(Id_Libro_ISBN)
create unique index indice_Libro_Autores on Libro_Autores(Id_Libro_Autores)
create unique index indice_Log on Logs(Id_Log)
create unique index indice_Nivel on Nivel(Id_Nivel)
create unique index indice_NivelVal on Nivel(Valor)
create unique index indice_Pais on Pais(id_Pais)
create unique index indice_PaisNombre on Pais(Nombre)
create unique index indice_PaisNacionalidad on Pais(Nacionalidad)
create unique index indice_Puesto on Puesto(Id_Puesto)
create unique index indice_PuestoNombre on Puesto(Nombre)
create unique index indice_Rating on Rating(Id_rating)
create unique index indice_RatingVal on Rating(Valor)
create unique index indice_Tipo_Cliente on Tipo_Cliente(Id_Tipo_Cliente)
create unique index indice_Tipo_ClienteNombre on Tipo_Cliente(Nombre)
create unique index indice_Tipo_Formato on Tipo_Formato(Id_Tipo_Formato)
create unique index indice_Tipo_FormatoNombre on Tipo_Formato(Nombre)
create unique index indice_Tipo_Pago on Tipo_Pago(Id_Tipo_Pago)
create unique index indice_Tipo_PagoNombre on Tipo_Pago(Nombre)
create unique index indice_Tipo_Usuario on Tipo_Usuario(Id_Tipo_Usuario)
create unique index indice_Tipo_UsuarioNombre on Tipo_Usuario(Nombre)
create unique index indice_Usuario on Usuario(Id_Usuario)
create unique index indice_UsuarioNombreUsuario on Usuario(Nombre_Usuario)
create unique index indice_UsuarioPersona on Usuario(Nombre_Usuario,Nombre,Apellido_Paterno,Apellido_Materno)
create unique index indice_Venta on Venta(Id_Venta)

