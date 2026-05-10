export enum FlowType {
  ImplicitFlow = 0,
  AuthorizationCode,
}

export default interface ClientModel {
  clientId: string;
  flowType: FlowType;
}
