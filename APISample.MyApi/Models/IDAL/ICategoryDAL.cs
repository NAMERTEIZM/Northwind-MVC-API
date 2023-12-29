﻿using APISample.MyApi.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.MyApi.Models.IDAL
{
	public interface ICategoryDAL :IDisposable
	{
		List<CategorySelectDTO> getAllCategory();
	}
}