/* Derived:
 * Zachary Yates
 * Copyright © 2007 YatesMorrison Software, LLC.
 * 11/23/2007
 * 
 * Original:
 * 
 */

using System;
using System;

namespace Za.Evaluator
{
	public enum VariantType 
	{
		vtUnknown,
		vtBool,
		vtInt,
		vtDouble,
		vtString,
		vtDateTime
	}

	public class VariantException : Exception { } 
	
	public class Variant
	{
		public object Value
		{
			get { return m_Value; }
			set { m_Value = value; }
		}
		object m_Value = null;

		public VariantType VariantType
		{
			get { return m_VariantType; }
		}
		VariantType m_VariantType;
		
		public Variant()
		{
			m_VariantType = VariantType.vtUnknown;
		}

		public Variant(object o) 
		{		
			if(o is bool) 
			{
				Value = (bool)o;
				m_VariantType = VariantType.vtBool;
				return;
			}
			if(o is int) 
			{
				Value = (int)o;
				m_VariantType = VariantType.vtInt;
				return;
			}
			if(o is double) 
			{
				Value = (double)o;
				m_VariantType = VariantType.vtDouble;
				return;
			}
			if(o is DateTime) 
			{
				Value = (DateTime)o;
				m_VariantType = VariantType.vtDateTime;
				return;
			}
			if(o is string) 
			{
				Value = (string)o;
				m_VariantType = VariantType.vtString;
				return;
			}
			if(o is Variant)
			{
				Value = ((Variant)o).Value;
				m_VariantType = ((Variant)o).VariantType;
				return;
			}
			if(o is System.Decimal) 
			{
				Value = (int)(decimal)o;
				m_VariantType = VariantType.vtInt;
				return;
			}
			if(o is long) 
			{
				Value = (int)(long)o;
				m_VariantType = VariantType.vtInt;
				return;
			}
			if(o is float) 
			{
				Value = (double)(float)o;
				m_VariantType = VariantType.vtDouble;
				return;
			}
			throw(new CalcException("Invalid object type for Variant conversion"));
		}

		public Variant(Variant v): this ((object) v){}		
		public Variant(bool b): this ((object)b){} 
		public Variant(int i): this ((object)i){}
		public Variant(double d): this ((object)d){}
		public Variant(string s): this ((object)s){}
		public Variant(DateTime dt): this ((object)dt){}

		public override string ToString()
		{
			switch(m_VariantType)
			{
				case VariantType.vtUnknown : return ""; 
				case VariantType.vtBool : return ((bool)Value).ToString();
				case VariantType.vtInt : return ((int)Value).ToString();
				case VariantType.vtDouble : return ((double)Value).ToString();
				case VariantType.vtString : return (string)Value.ToString();
				case VariantType.vtDateTime : return ((DateTime)Value).ToString();
				default : return "";
			}
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}
		public override bool Equals(object o)
		{
			return false;
		}
	
		public static implicit operator bool(Variant v)
		{
			switch(v.VariantType)
			{
				case VariantType.vtBool:
					return (bool)v.Value;
				default:
					throw new CalcException("Bad typecast from " + v.VariantType + " to bool");
			}
		}

		public static implicit operator int(Variant v)
		{
			switch(v.VariantType)
			{
				case VariantType.vtInt:
					return (int)v.Value;
				case VariantType.vtDouble:
					return (int)(double)v.Value;
				default:
					throw new CalcException("Bad typecast from " + v.VariantType + " to int");
			}
		}
		public static implicit operator double(Variant v)
		{
			switch(v.VariantType)
			{
				case VariantType.vtInt:
					return (double)(int)v.Value;
				case VariantType.vtDouble:
					return (double)v.Value;
				default:
					throw new CalcException("Bad typecast from " + v.VariantType + " to double");
			}
		}
		public static implicit operator DateTime(Variant v)
		{
			switch(v.VariantType)
			{
				case VariantType.vtDateTime:
					return (DateTime)v.Value;
				default:
					throw new CalcException("Bad typecast from " + v.VariantType + " to DateTime");
			}
		}

		public static implicit operator string(Variant v)
		{
			if(v.m_VariantType == VariantType.vtUnknown)
				return "";
			else
				return v.ToString();
		}

		public static implicit operator Variant(string s)
		{
			return new Variant(s);
		}

		public static Variant operator -(Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtInt:			
					return new Variant(-(int)a.Value);
				case VariantType.vtDouble:
					return new Variant(-(double)a.Value);
				case VariantType.vtBool:
					return new Variant(!(bool)a.Value);
				default: 
					throw(new CalcException("Bad operand type for UnMinus operator"));
			}
		}	

		public static Variant operator !(Variant a)
		{
			return new Variant(-a);
		}	

		public static Variant operator +(Variant a)
		{
			return new Variant(a);
		}	

		public static Variant operator +(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool: 
					switch(b.m_VariantType)
					{
						case VariantType.vtString: return new Variant(a.ToString() + b.ToString());
						default: 
							throw(new CalcException("Bad 2-nd operand type with plus operator"));
					}
				case VariantType.vtInt:			
					switch(b.m_VariantType)
					{
						case VariantType.vtBool: 
							throw(new CalcException("Bad 2-st operand bool type with plus operator"));
						case VariantType.vtInt: 
							return new Variant((int)a.Value + (int)b.Value);
						case VariantType.vtDouble: 
							return new Variant((int)a.Value + (double)b.Value);
						case VariantType.vtString: 
							return new Variant(a.ToString() + b.ToString());
						case VariantType.vtDateTime: 
							throw(new CalcException("Bad 2-st operand datetime type with plus operator"));		
						default: 
							throw(new CalcException("Bad 2-nd operand type with plus operator"));
					}
				case VariantType.vtDouble:
					switch(b.m_VariantType)
					{
						case VariantType.vtBool: 
							throw(new CalcException("Bad 2-st operand bool type with plus operator"));
						case VariantType.vtInt: 
							return new Variant((double)a.Value + (int)b.Value);
						case VariantType.vtDouble: 
							return new Variant((double)a.Value + (double)b.Value);
						case VariantType.vtString: 
							return new Variant(a.ToString() + b.ToString());
						case VariantType.vtDateTime: 
							throw(new CalcException("Bad 2-st operand datetime type with plus operator"));		
						default: 
							throw(new CalcException("Bad 2-nd operand type with plus operator"));
					}
				case VariantType.vtString:
					switch(b.m_VariantType)
					{
						case VariantType.vtBool: 
						case VariantType.vtInt: 
						case VariantType.vtDouble: 
						case VariantType.vtString: 
						case VariantType.vtDateTime: 
							return new Variant(a.ToString() + b.ToString());
						default: 
							throw(new CalcException("Bad 2-nd operand type with plus operator"));
					}
				default: 
					throw(new CalcException("Bad 1-st operand type with plus operator"));
			}
		}

		public static Variant operator -(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtInt:			
					switch(b.m_VariantType)
					{
						case VariantType.vtInt: 
							return new Variant((int)a.Value - (int)b.Value);
						case VariantType.vtDouble: 
							return new Variant((int)a.Value - (double)b.Value);
						default: 
							throw(new CalcException("Bad 2-nd operand type with plus operator"));
					}
				case VariantType.vtDouble:
					switch(b.m_VariantType)
					{
						case VariantType.vtInt: 
							return new Variant((double)a.Value + (int)b.Value);
						case VariantType.vtDouble: 
							return new Variant((double)a.Value + (double)b.Value);
						default: 
							throw(new CalcException("Bad 2-nd operand type with minus operator"));
					}
				default: 
					throw(new CalcException("Bad 1-st operand type with plus operator"));
			}
		}	
		public static Variant operator *(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((int)a.Value * (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value * (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with mul operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value * (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value * (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with mul operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with mul operator"));
			}
		}		
		public static Variant operator /(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						if((int)b.Value == 0) return new Variant(0);
						else return new Variant((int)a.Value / (int)b.Value);
					case VariantType.vtDouble: 
						if((double)b.Value == 0) return new Variant(0.0);
						else return new Variant((int)a.Value / (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with div operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						if((int)b.Value == 0) return new Variant(0.0);
						else return new Variant((double)a.Value / (int)b.Value);
					case VariantType.vtDouble: 
						if((double)b.Value == 0) return new Variant(0.0);
						else return new Variant((double)a.Value / (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with div operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with div operator"));
			}
		}		
		public static Variant operator >(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool:
				switch(b.m_VariantType)
				{
					case VariantType.vtBool:
						if((bool)a.Value && !(bool)b.Value)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with > operator"));
				}
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtBool: 
						throw(new CalcException("Bad 2-st operand bool type with > operator"));
					case VariantType.vtInt: 
						return new Variant((int)a.Value > (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value > (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with > operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value > (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value > (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with > operator"));
				}
				case VariantType.vtString:
				switch(b.m_VariantType)
				{
					case VariantType.vtString:
						if(String.Compare(a.ToString(),b.ToString(),true) > 0)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with > operator"));
				}
				case VariantType.vtDateTime:
				switch(b.m_VariantType)
				{
					case VariantType.vtDateTime: 
						return new Variant((DateTime)a.Value > (DateTime)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with > operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with > operator"));
			}
		}

		public static Variant operator <(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool:
				switch(b.m_VariantType)
				{
					case VariantType.vtBool:
						if(!(bool)a.Value && (bool)b.Value)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with < operator"));
				}
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtBool: 
						throw(new CalcException("Bad 2-st operand bool type with < operator"));
					case VariantType.vtInt: 
						return new Variant((int)a.Value < (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value < (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with < operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value < (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value < (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with < operator"));
				}
				case VariantType.vtString:
				switch(b.m_VariantType)
				{
					case VariantType.vtString:
						if(String.Compare(a.ToString(),b.ToString(),true) < 0)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with < operator"));
				}
				case VariantType.vtDateTime:
				switch(b.m_VariantType)
				{
					case VariantType.vtDateTime: 
						return new Variant((DateTime)a.Value < (DateTime)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with < operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with < operator"));
			}
		}

		public static Variant operator >=(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool:
				switch(b.m_VariantType)
				{
					case VariantType.vtBool:
						if(!(bool)a.Value && (bool)b.Value)
							return new Variant(false);
						else
							return new Variant(true);
					default: 
						throw(new CalcException("Bad 2-nd operand type with >= operator"));
				}
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtBool: 
						throw(new CalcException("Bad 2-st operand bool type with >= operator"));
					case VariantType.vtInt: 
						return new Variant((int)a.Value >= (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value >= (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with >= operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value >= (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value >= (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with >= operator"));
				}
				case VariantType.vtString:
				switch(b.m_VariantType)
				{
					case VariantType.vtString:
						if(String.Compare(a.ToString(),b.ToString(),true) >= 0)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with >= operator"));
				}
				case VariantType.vtDateTime:
				switch(b.m_VariantType)
				{
					case VariantType.vtDateTime: 
						return new Variant((DateTime)a.Value >= (DateTime)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with >= operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with >= operator"));
			}
		}
		public static Variant operator <=(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool:
				switch(b.m_VariantType)
				{
					case VariantType.vtBool:
						if((bool)a.Value && !(bool)b.Value)
							return new Variant(false);
						else
							return new Variant(true);
					default: 
						throw(new CalcException("Bad 2-nd operand type with <= operator"));
				}
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtBool: 
						throw(new CalcException("Bad 2-st operand bool type with <= operator"));
					case VariantType.vtInt: 
						return new Variant((int)a.Value <= (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value <=(double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with <= operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value <= (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value <= (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with <= operator"));
				}
				case VariantType.vtString:
				switch(b.m_VariantType)
				{
					case VariantType.vtString:
						if(String.Compare(a.ToString(),b.ToString(),true) <= 0)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with <= operator"));
				}
				case VariantType.vtDateTime:
				switch(b.m_VariantType)
				{
					case VariantType.vtDateTime: 
						return new Variant((DateTime)a.Value <= (DateTime)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with <= operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with <= operator"));
			}
		}

		public static Variant operator ==(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool:
				switch(b.m_VariantType)
				{
					case VariantType.vtBool:
						if((bool)a.Value ^ (bool)b.Value)
							return new Variant(false);
						else
							return new Variant(true);
					default: 
						throw(new CalcException("Bad 2-nd operand type with == operator"));
				}
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtBool: 
						throw(new CalcException("Bad 2-st operand bool type with == operator"));
					case VariantType.vtInt: 
						return new Variant((int)a.Value == (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value ==(double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with == operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value == (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value == (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with == operator"));
				}
				case VariantType.vtString:
				switch(b.m_VariantType)
				{
					case VariantType.vtString:
						if(String.Compare(a.ToString(),b.ToString(),true) == 0)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with == operator"));
				}
				case VariantType.vtDateTime:
				switch(b.m_VariantType)
				{
					case VariantType.vtDateTime: 
						return new Variant((DateTime)a.Value == (DateTime)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with == operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with == operator"));
			}
		}
		public static Variant operator !=(Variant b,  Variant a)
		{
			switch(a.m_VariantType)
			{
				case VariantType.vtBool:
				switch(b.m_VariantType)
				{
					case VariantType.vtBool:
						if((bool)a.Value ^ (bool)b.Value)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with != operator"));
				}
				case VariantType.vtInt:			
				switch(b.m_VariantType)
				{
					case VariantType.vtBool: 
						throw(new CalcException("Bad 2-st operand bool type with != operator"));
					case VariantType.vtInt: 
						return new Variant((int)a.Value != (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((int)a.Value !=(double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with != operator"));
				}
				case VariantType.vtDouble:
				switch(b.m_VariantType)
				{
					case VariantType.vtInt: 
						return new Variant((double)a.Value != (int)b.Value);
					case VariantType.vtDouble: 
						return new Variant((double)a.Value != (double)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with != operator"));
				}
				case VariantType.vtString:
				switch(b.m_VariantType)
				{
					case VariantType.vtString:
						if(String.Compare(a.ToString(),b.ToString(),true) != 0)
							return new Variant(true);
						else
							return new Variant(false);
					default: 
						throw(new CalcException("Bad 2-nd operand type with != operator"));
				}
				case VariantType.vtDateTime:
				switch(b.m_VariantType)
				{
					case VariantType.vtDateTime: 
						return new Variant((DateTime)a.Value <= (DateTime)b.Value);
					default: 
						throw(new CalcException("Bad 2-nd operand type with != operator"));
				}
				default: 
					throw(new CalcException("Bad 1-st operand type with != operator"));
			}
		}
	}	
}