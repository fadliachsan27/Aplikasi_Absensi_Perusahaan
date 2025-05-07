using System;
using System.Collections.Generic;

namespace Aplikasi_Absensi_Perusahaan.Services
{
	public class MengelolaData<T>
	{
		private List<T> dataList;

		public MengelolaData(List<T> initialData = null)
		{
			dataList = initialData ?? new List<T>();
		}

		public void TambahData(T data)
		{
			dataList.Add(data);
		}

		public void HapusData(Predicate<T> predicate)
		{
			dataList.RemoveAll(predicate);
		}

		public T CariData(Predicate<T> predicate)
		{
			return dataList.Find(predicate);
		}

		public List<T> GetSemuaData()
		{
			return dataList;
		}

		public void UpdateData(Predicate<T> predicate, Action<T> updateAction)
		{
			var item = dataList.Find(predicate);
			if (item != null)
			{
				updateAction(item);
			}
		}

		public void TampilkanData(Action<T> tampilkan)
		{
			foreach (var item in dataList)
			{
				tampilkan(item);
			}
		}
	}
}
