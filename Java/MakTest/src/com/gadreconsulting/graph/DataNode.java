package com.gadreconsulting.graph;

import java.util.UUID;

import com.gadreconsulting.BinaryTree.Tester.CityInfo;
import com.gadreconsulting.DynamicArray.DynamicArray;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author gadre
 */
public class DataNode<T> {
	public DynamicArray<DataNode<T>> _dynArrLinkedNode;
	public T _objData;
	public String _sUniqId;

	public DataNode(T objData) {
		_objData = objData;
		_dynArrLinkedNode = new DynamicArray<>();
		_sUniqId = UUID.randomUUID().toString();
	}
	public  void establishTwoWayLink(DataNode<T> dnOther) {
		if (!this._dynArrLinkedNode.fContains(dnOther)) {
			this._dynArrLinkedNode.add(dnOther);
		}
		if (!dnOther._dynArrLinkedNode.fContains(this)) {
			dnOther._dynArrLinkedNode.add(this);
		}
	}
	public String toString() {
		return _objData.toString();
	}
}
