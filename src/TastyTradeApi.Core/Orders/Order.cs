namespace TastyTradeApi.Core.Orders;

using System;
using System.Collections.Generic;

public record Fill(
    string ExtGroupFillId,
    string ExtExecId,
    string FillId,
    int Quantity,
    string FillPrice,
    DateTime FilledAt,
    string DestinationVenue);

public record Leg(
    string InstrumentType,
    string Symbol,
    int Quantity,
    int RemainingQuantity,
    string Action,
    IList<Fill> Fills);

public record OrderCondition(
    string InstrumentType,
    DateTime TriggeredAt,
    string Threshold,
    bool IsThresholdBasedOnNotional,
    string Indicator,
    string Comparator,
    string Action,
    string Symbol,
    IList<PriceComponent> PriceComponents,
    string TriggeredValue,
    string Id);

public record PriceComponent(
    string Symbol,
    string InstrumentType,
    int Quantity,
    string QuantityDirection);

public record OrderRule(
    DateTime RouteAfter,
    DateTime RoutedAt,
    DateTime CancelAt,
    DateTime CancelledAt,
    IList<OrderCondition> OrderConditions);

public record Order(
    int Size,
    string TimeInForce,
    DateTime TerminalAt,
    bool Editable,
    string ContingentStatus,
    IList<Leg> Legs,
    DateTime GtcDate,
    long UpdatedAt,
    DateTime InFlightAt,
    string ReplacesOrderId,
    string UnderlyingSymbol,
    bool Edited,
    string Price,
    string CancelUsername,
    string AccountNumber,
    string ConfirmationStatus,
    string CancelUserId,
    bool Cancellable,
    string ValueEffect,
    string StopTrigger,
    DateTime CancelledAt,
    string UnderlyingInstrumentType,
    string Value,
    string RejectReason,
    string Status,
    DateTime LiveAt,
    string PreflightId,
    string PriceEffect,
    string Username,
    string ReplacingOrderId,
    string ComplexOrderId,
    string OrderType,
    long Id,
    OrderRule OrderRule,
    string UserId,
    string ComplexOrderTag,
    DateTime ReceivedAt
);
