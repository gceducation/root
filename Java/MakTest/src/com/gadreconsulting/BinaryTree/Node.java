package com.gadreconsulting.BinaryTree;

public class Node<T> {
	public int _jDist;
	public Node<T> _nodeChildL;
	public Node<T> _nodeChildR;
	public Node<T> _nodeParent;
	public T _tPayload;

	public Node(T objData) {
		_nodeChildL = null;
		_nodeChildR = null;
		_tPayload = objData;
		_jDist = 0;
	}

	private Node() {
		_nodeParent = null;
		_nodeChildL = null;
		_nodeChildR = null;
		_tPayload = null;
		_jDist = 0;
	}

	public String toString() {
		return _tPayload.toString();
	}
}