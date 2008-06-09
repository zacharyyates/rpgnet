// © 2006 IDesign Inc. All rights reserved 
//Questions? Comments? go to 
//http://www.idesign.net

using System.Runtime.Serialization;
using System.ServiceModel;

//For transient subscribers
[ServiceContract]
public interface ISubscriptionService
{
   [OperationContract]
   void Subscribe(string eventOperation);

   [OperationContract]
   void Unsubscribe(string eventOperation);
}
//For persistent subscribers
[DataContract]
public struct PersistentSubscription
{
   [DataMember]
   string m_Address;

   [DataMember]
   string m_EventsContract;

   [DataMember]
   string m_EventOperation;

   public string Address
   {
      get
      {
         return m_Address;
      }
      set
      {
         m_Address = value;
      }
   }
   public string EventsContract
   {
      get
      {
         return m_EventsContract;
      }
      set
      {
         m_EventsContract = value;
      }
   }
   public string EventOperation
   {
      get
      {
         return m_EventOperation;
      }
      set
      {
         m_EventOperation = value;
      }
   }
}

[ServiceContract]
public interface IPersistentSubscriptionService
{
   [OperationContract]
   [TransactionFlow(TransactionFlowOption.Allowed)]
   void Subscribe(string address,string eventsContract,string eventOperation);

   [OperationContract]
   [TransactionFlow(TransactionFlowOption.Allowed)]
   void Unsubscribe(string address,string eventsContract,string eventOperation);

   [OperationContract]
   [TransactionFlow(TransactionFlowOption.Allowed)]
   PersistentSubscription[] GetAllSubscribers();

   [OperationContract]
   [TransactionFlow(TransactionFlowOption.Allowed)]
   PersistentSubscription[] GetSubscribersToContract(string eventsContract);

   [OperationContract]
   [TransactionFlow(TransactionFlowOption.Allowed)]
   string[] GetSubscribersToContractEventType(string eventsContract,string eventOperation);

   [OperationContract]
   [TransactionFlow(TransactionFlowOption.Allowed)]
   PersistentSubscription[] GetAllSubscribersFromAddress(string address);
}