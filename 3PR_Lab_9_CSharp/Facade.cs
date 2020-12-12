using System;
using System.Collections.Generic;
using System.Text;

namespace _3PR_Lab_9_CSharp
{
	class Facade
	{
		private int windowsAmount;
		private int openedWindowsAmount;
		public int WindowsAmount
		{
			get
			{
				return windowsAmount;
			}
			set
			{
				windowsAmount = value;
			}
		}
		public int OpenedWindowsAmount
		{
			get
			{
				return openedWindowsAmount;
			}
			set
			{
				openedWindowsAmount = value;
			}
		}
		// Функция, выводящая приватные поля в консоль.
		public void getFacade()
		{
			Console.WriteLine("Общее количество окон: " + windowsAmount);
			Console.WriteLine("Количество открытых окон: " + openedWindowsAmount);
		}
		// Функция по вводу полей.
		public void inputFacade()
		{
			Console.Write("Введите общее количество окон вашего здания: ");
			while (!(int.TryParse(Console.ReadLine(), out windowsAmount)) || windowsAmount < 0)
			{
				Console.Write("Неверный ввод количества окон - оно должно быть целым неотрицательным числом. Попробуйте еще раз: ");
			}

			Console.Write("Введите количество открытых окон вашего здания: ");
			while (!(int.TryParse(Console.ReadLine(), out openedWindowsAmount)) || openedWindowsAmount < 0 || openedWindowsAmount > windowsAmount)
			{
				Console.Write("Неверный ввод количества открытых окон - оно должно быть не меньше нуля и не больше общего числа окон. Попробуйте еще раз: ");
			}
		}
		// Функция по открытию определенного числа окон.
		public void openWindows()
		{
			int windowsToOpen;
			Console.Write("Введите количество окон, которые вы хотите открыть: ");
			while (!(int.TryParse(Console.ReadLine(), out windowsToOpen)) || windowsToOpen < 0 || windowsToOpen > (windowsAmount - openedWindowsAmount))
			{
				Console.Write("Неверный ввод количества окон для открытия - оно должно быть не меньше нуля и не больше возможного для открытия числа окон. Попробуйте еще раз: ");
			}

			openedWindowsAmount += windowsToOpen;
		}
		// Функция по закрытию определенного числа окон.
		public void closeWindows()
		{
			int windowsToClose;
			Console.Write("Введите количество окон, которые вы хотите закрыть: ");
			while (!(int.TryParse(Console.ReadLine(), out windowsToClose)) || windowsToClose < 0 || windowsToClose > openedWindowsAmount)
			{
				Console.Write("Неверный ввод количества окон для закрытия - оно должно быть не меньше нуля и не больше числа открытых окон. Попробуйте еще раз: ");
			}

			openedWindowsAmount -= windowsToClose;
		}

		public static Facade operator +(Facade firstFacade, Facade secondFacade)
		{
			Facade resultF = new Facade();

			resultF.windowsAmount = firstFacade.windowsAmount + secondFacade.windowsAmount;
			resultF.openedWindowsAmount = firstFacade.openedWindowsAmount + secondFacade.openedWindowsAmount;

			return resultF;
		}
	};
}